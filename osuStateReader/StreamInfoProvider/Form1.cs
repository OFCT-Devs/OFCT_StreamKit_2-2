using Newtonsoft.Json.Linq;
using OsuMemoryDataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.Security.Permissions;

namespace osuStateReader
{
	public partial class Form1 : Form
	{
		readonly String _osuWindowTitleHint;
		readonly IOsuMemoryReader _reader;
		Thread pulseThread;
		Thread tourneyThread;

		int updateDelay = 33;
		int offset = 0;

		String osuPath = "";

		int mapID = 0;
		int mapSetID = 0;
		int mapLength = 0;
		int playTime = 0;
		bool osuRunning = false;
		String songString = "";

		List<List<float>> timingPoints = new List<List<float>>();
		List<int> timeToPulseList = new List<int>();
		int pulseCount = 0;

		readonly String titleFileLocation = @"./SongTitle.txt";
		readonly String diffTitleFileLocation = @"./SongDiffTitle.txt";
		readonly String configFileLocation = @"../osuStateReaderConfig.cfg";

		WebSocketServer ws = new WebSocketServer("ws://127.0.0.1");
		List<Label> wsLabels = new List<Label>();

		public static Form1 F1;

		public Form1(string osuWindowTitleHint)
		{
			_osuWindowTitleHint = osuWindowTitleHint;
			InitializeComponent();
			_reader = OsuMemoryReader.Instance.GetInstanceForWindowTitleHint(osuWindowTitleHint);
			Closing += OnClosing;
			ReadingDelay.ValueChanged += DelaySettingChange;
			Offset.ValueChanged += OffsetSettingChange;

			wsLabels.Add(PulseLabel);
			wsLabels.Add(TourneyStateLabel);
			wsLabels.Add(ChatLabel);

			F1 = this;

			ws.AddWebSocketService<pulse>("/pulse");
			ws.AddWebSocketService<tourenyState>("/tourneyState");
			ws.AddWebSocketService<chat>("/chat");
			ws.Start();

			if (!File.Exists(configFileLocation))
			{
				CreateSettingsFile();
			}

			if (!string.IsNullOrEmpty(ReadSettingsFile("UpdateDelay")))
			{
				updateDelay = int.Parse(ReadSettingsFile("UpdateDelay"));
			}
			else
			{
				updateDelay = 33;
				WriteSetting("UpdateDelay", "33");
			}
			ReadingDelay.Value = updateDelay;

			if (!string.IsNullOrEmpty(ReadSettingsFile("Offset")))
			{
				offset = int.Parse(ReadSettingsFile("Offset"));
			}
			else
			{
				offset = 0;
				WriteSetting("Offset", "0");
			}
			Offset.Value = offset;
		}

		private void Form1_Load(object sender, EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty(_osuWindowTitleHint)) Text += $": { _osuWindowTitleHint}";
			pulseThread = new Thread(() =>
			{
				try
				{
					while (true)
					{
						var status = _reader.GetCurrentStatus(out var num);
						if (status.ToString() != "NotRunning")
						{
							if (osuRunning != true)
							{
								osuRunning = true;
								OsuLunched();
							}

							if (mapID != _reader.GetMapId())
							{
								mapID = _reader.GetMapId();
								mapSetID = (int)_reader.GetMapSetId();
								MapChanged();
							}

							UpdatePlayTime();

							/*foreach (int value in timeToPulseList)
                            {
                                Console.WriteLine(value);
                            }*/

							if (timeToPulseList.Count > 0)
							{
								try
								{
									if (playTime - 1000 >= timeToPulseList[pulseCount] + offset || playTime + 1000 <= timeToPulseList[pulseCount] + offset)
									{
										for (int i = 0; i < timeToPulseList.Count - 1; i++)
										{
											if (playTime >= timeToPulseList[i] && playTime <= timeToPulseList[i + 1])
											{
												pulseCount = i;
												break;
											}
										}
									}
									if (playTime >= timeToPulseList[pulseCount] + offset)
									{
										GeneratePulse();
										pulseCount++;
										int currentBPM = (int)Math.Round(60000.0 / (timeToPulseList[pulseCount] - timeToPulseList[pulseCount - 1]), MidpointRounding.AwayFromZero);
										Invoke(new Action(() =>
										{
											BPM.Text = currentBPM.ToString();
										}));
									}
								}
								catch (ArgumentOutOfRangeException)
								{
								}
							}
						}
						else
						{
							updateDelay = 1000;
							osuRunning = false;
							Invoke(new Action(() =>
							{
								osuRunningLabel.Text = "osu! Process Not Found.";
								osuRunningLabel.ForeColor = System.Drawing.Color.Red;
								ArtistTitleOutput.Text = "";
								SongPosition.Text = "";
								SongProgress.Value = 0;
							}));
						}
						Thread.Sleep(updateDelay);
					}
				}
				catch (ThreadAbortException)
				{
				}
			});
			pulseThread.Start();

			tourneyThread = new Thread(() =>
			{
				while (true)
				{
					int[] scores = new int[2];
					int channel = 0;
					String state = "";
					String textToSend = "";

					try
					{
						if (File.Exists(osuPath + "ipc-scores.txt"))
						{
							scores[0] = int.Parse(File.ReadAllLines(osuPath + "ipc-scores.txt")[0]);
							scores[1] = int.Parse(File.ReadAllLines(osuPath + "ipc-scores.txt")[1]);
						}
						if (File.Exists(osuPath + "ipc-channel.txt"))
						{
							channel = int.Parse(File.ReadAllLines(osuPath + "ipc-channel.txt")[0]);
						}
						if (File.Exists(osuPath + "ipc-state.txt"))
						{
							state = File.ReadAllLines(osuPath + "ipc-state.txt")[0];
						}
						textToSend = "{\"redScore\":" + scores[0] + ", \"blueScore\":" + scores[1] + ", \"channel\":" + channel + ", \"state\":\"" + state + "\", \"mapID\" : " + mapID + ", \"mapSetID\" : " + mapSetID + "}";
					}
					catch (IOException) { }

					try
					{
						ws.WebSocketServices["/tourneyState"].Sessions.Broadcast(textToSend);
					}
					catch (WebSocketException) { }
					Thread.Sleep(100);
				}
			});
			tourneyThread.Start();
		}

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		void OsuLunched()
		{
			Process[] osuProcesses = Process.GetProcessesByName("osu!");
			osuPath = osuProcesses[0].MainModule.FileName;
			osuPath = osuPath.Substring(0, osuPath.Length - "osu!.exe".Length);

			updateDelay = int.Parse(ReadSettingsFile("UpdateDelay"));
			Invoke(new Action(() =>
			{
				ReadingDelay.Value = updateDelay;
				osuRunningLabel.Text = "osu! Process Found.";
				osuRunningLabel.ForeColor = System.Drawing.Color.Green;
			}));

			Console.WriteLine(osuPath + "chat.log");

			if(File.Exists(osuPath + "chat.log"))
			{
				FileSystemWatcher watcher = new FileSystemWatcher();
				watcher.Path = osuPath;
				/* Watch for changes in LastAccess and LastWrite times, and 
				   the renaming of files or directories. */
				watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
				   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
				// Only watch text files.
				watcher.Filter = "chat.log";

				// Add event handlers.
				watcher.Changed += new FileSystemEventHandler(ChatUpdate);

				// Begin watching.
				watcher.EnableRaisingEvents = true;
			}			
		}
		public void WebSocketConnected(int client)
		{
			Invoke(new Action(() =>
			{
				wsLabels[client].ForeColor = System.Drawing.Color.Green;
			}));
		}
		public void WebSocketDisconnected(int client)
		{
			Invoke(new Action(() =>
			{
				wsLabels[client].ForeColor = System.Drawing.Color.Red;
			}));
		}

		void MapChanged()
		{
			pulseCount = 0;
			timingPoints.Clear();
			timeToPulseList.Clear();
			var mapFolder = _reader.GetMapFolderName();
			var osuFile = _reader.GetOsuFileName();

			//mapLength = GetMapLength();
			songString = _reader.GetSongString();
			File.WriteAllText(diffTitleFileLocation, songString);
			songString = Regex.Replace(songString, @" \[.*\]", "");
			File.WriteAllText(titleFileLocation, songString);
			
			//Console.WriteLine(@osuPath + @"Songs\");
			//String[] osuFile = Directory.GetFiles(@osuPath + @"Songs\", _reader.GetOsuFileName(), SearchOption.AllDirectories);
			File.Delete("./osuFile.txt");
			try
			{
				File.Copy(osuPath + @"Songs\" + mapFolder + @"\" + osuFile, "osuFile.txt");
			}
			catch (FileNotFoundException)
			{
				Thread.Sleep(1000);
				MapChanged();
			}
			catch (IndexOutOfRangeException) { }
			catch (DirectoryNotFoundException)
			{
				Thread.Sleep(1000);
				MapChanged();
			}
			catch (ArgumentException)
			{
				Thread.Sleep(1000);
				MapChanged();
			}
			/*{
				Thread.Sleep(100000);
				MapChanged();
			}*/
			//Console.WriteLine(osuFile.Length);
			//Console.WriteLine(osuFile[0]);

			try
			{
				var osuFileContent = "";

				if (File.Exists(@"./osuFile.txt"))
				{
					osuFileContent = File.ReadAllText(@"./osuFile.txt");
				}
				else
				{
					return;
				}

				var audioName = osuFileContent.Substring(osuFileContent.IndexOf("AudioFilename: ") + "AudioFileName: ".Length);
				audioName = audioName.Split(new[] { '\r', '\n' })[0];

				mapLength = GetAudioDuration(osuPath + @"Songs\" + mapFolder + @"\" + audioName);
				GetAudioDuration(osuPath + @"Songs\" + mapFolder + @"\" + audioName);

				Console.WriteLine(audioName);

				var timingPointsText = osuFileContent.Substring(osuFileContent.IndexOf("[TimingPoints]") + 15);
				timingPointsText = timingPointsText.Substring(0, timingPointsText.IndexOf("[") - 2);
				//Console.WriteLine(timingPoints);

				String[] timingPointsArray = timingPointsText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
				for (int i = 0; i < timingPointsArray.Length; i++)
				{
					timingPointsArray[i] = timingPointsArray[i].Replace("\n", "");
					timingPointsArray[i] = timingPointsArray[i].Replace("\r", "");
				}

				/*Console.WriteLine(timingPointsArray.Length);

				Console.WriteLine(timingPointsArray[timingPointsArray.Length-3]);
				Console.WriteLine(timingPointsArray[0].Split(',')[0]);*/

				/*for(var i = 0; i < timingPointsArray.Length; i++)
				{
					if (!timingPointsArray[timingPointsArray.Length - i - 1].IsNullOrEmpty())
					{
						mapLength = int.Parse(timingPointsArray[timingPointsArray.Length - i].Split(',')[0]);
					}
				}*/

				Invoke(new Action(() =>
				{
					SongProgress.Minimum = 0;
					SongProgress.Maximum = mapLength;
					ArtistTitleOutput.Text = songString;
				}));
				Console.WriteLine(mapLength);

				List<String> timingPointsListAA = new List<string>();

				for (int i = 0; i < timingPointsArray.Length; i++)
				{
					if (!timingPointsArray[i].Contains(",-") && !timingPointsArray[i].IsNullOrEmpty())
					{
						timingPointsListAA.Add(timingPointsArray[i]);
					}
				}

				for (int i = 0; i < timingPointsListAA.Count; i++)
				{
					List<float> list = new List<float>();
					for (int j = 0; j < 2; j++)
					{
						try
						{
							list.Add(float.Parse(timingPointsListAA[i].Split(',')[j]));
						}
						catch (OverflowException) { return; }
						//catch (FormatException) { return; }
					}
					timingPoints.Add(list);
					list = null;
				}

				timingPointsListAA = null;

				float time = timingPoints[0][0];
				for (int i = 0; i < timingPoints.Count; i++)
				{
					while (true)
					{
						timeToPulseList.Add((int)(time + timingPoints[i][1]));
						time += timingPoints[i][1];
						if (i == timingPoints.Count - 1)
						{
							if (time >= (mapLength + 100) * 1000)
							{
								break;
							}
						}
						else
						{
							if (time >= timingPoints[i + 1][0])
							{
								break;
							}
						}
					}
				}
				int[] aaa = timeToPulseList.ToArray();
				File.Delete("./TimingPoints.txt");
				TextWriter tw = new StreamWriter("./TimingPoints.txt");
				for (int i = 0; i < aaa.Length; i++)
				{
					tw.WriteLine(aaa[i].ToString());
				}
				tw.Close();
			}
			/*catch (IndexOutOfRangeException)
			{
				Thread.Sleep(1000);
				MapChanged();
			}*/
			catch (OutOfMemoryException)
			{
				timeToPulseList.Clear();
			}
		}

		void UpdatePlayTime()
		{
			playTime = _reader.ReadPlayTime();
			Invoke((MethodInvoker)(() =>
			{
				SongPosition.Text = playTime.ToString();
			}));

			if (playTime > mapLength)
			{
				Invoke(new Action(() =>
				{
					SongProgress.Value = mapLength;
				}));
			}
			else if (playTime < 0)
			{
				Invoke(new Action(() =>
				{
					SongProgress.Value = 0;
				}));
			}
			else
			{
				Invoke(new Action(() =>
				{
					SongProgress.Value = playTime;
				}));
			}
		}

		int GetMapLength()
		{
			using (WebClient wc = new WebClient())
			{
				var rawJSON = new WebClient().DownloadString("https://osu.ppy.sh/api/get_beatmaps?k=70da7e9652da3b201ca9e04231716b7e9acbe8b9&b=" + _reader.GetMapId());
				//Console.WriteLine(rawJSON.ToString());
				try
				{
					var json = JObject.Parse(rawJSON.Substring(1, rawJSON.Length - 2));
					return ((int)json["total_length"]);
				}
				catch (Newtonsoft.Json.JsonReaderException)
				{
					return 0;
				}
			}
		}

		int GetAudioDuration(string filePath)
		{
			try
			{
				using (var shell = ShellObject.FromParsingName(filePath))
				{
					Console.WriteLine(filePath);
					IShellProperty prop = shell.Properties.System.Media.Duration;
					ulong t = 0;
					try
					{
						t = (ulong)prop.ValueAsObject;
					}
					catch (NullReferenceException) { }
					return (int)(t / 10000);
				}
			}
			catch (ShellException)
			{
				Thread.Sleep(1000);
				return 0;
			}
		}

		void GeneratePulse()
		{
			Console.WriteLine("Pulse : " + playTime);
			ws.WebSocketServices["/pulse"].Sessions.Broadcast("pulse");

			Invoke(new Action(() =>
			{
				if (BPMcircle.Visible)
				{
					BPMcircle.Visible = false;
				}
				else
				{
					BPMcircle.Visible = true;
				}
			}));

			/*MediaPlayer simpleSound = new MediaPlayer();
			simpleSound.Open(new Uri(@"D:\OneDrive - yhsphd\osu!\Skins\yhsphdSkinV9\normal-hitclap.wav"));
			simpleSound.Volume = 0.1f;
			simpleSound.Play();*/
		}

		void DelaySettingChange(object sender, EventArgs eventArgs)
		{
			WriteSetting("UpdateDelay", ReadingDelay.Value.ToString());
			updateDelay = int.Parse(ReadingDelay.Value.ToString());
		}

		void OffsetSettingChange(object sender, EventArgs eventArgs)
		{
			WriteSetting("Offset", Offset.Value.ToString());
			offset = int.Parse(Offset.Value.ToString());
		}

		void ChatUpdate(object source, FileSystemEventArgs e)
		{
			Console.WriteLine("Chat Update!!");
			for (int i = 0; i < 3; i++)
			{
				try
				{
					//Console.WriteLine(File.ReadAllText(osuPath + "chat.log"));
					ws.WebSocketServices["/chat"].Sessions.Broadcast(File.ReadAllText(osuPath + "chat.log"));
					break;
				}
				catch (IOException)
				{
					Thread.Sleep(50);
				}
			}
		}

		void CreateSettingsFile()
		{
			string[] lines = { "osu!StateReader 설정 파일", "", "UpdateDelay : 33", "Offset : 0" };
			File.WriteAllLines(configFileLocation, lines);
		}

		String ReadSettingsFile(String tag)
		{
			string[] lines = File.ReadAllLines(configFileLocation);
			foreach (string line in lines)
			{
				if (line.StartsWith(tag + " : "))
				{
					return Regex.Replace(line, tag + " : ", "");
				}
			}
			return "";
		}

		void WriteSetting(String tag, String value)
		{
			string[] lines = File.ReadAllLines(configFileLocation);
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].StartsWith(tag + " : "))
				{
					lines[i] = tag + " : " + value;
				}
			}
			File.WriteAllLines(configFileLocation, lines);
		}

		void OnClosing(object sender, CancelEventArgs cancelEventArgs)
		{
			pulseThread?.Abort();
			tourneyThread?.Abort();
		}
	}
}
