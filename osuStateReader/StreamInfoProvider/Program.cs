using System;
using System.Linq;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace osuStateReader
{
	public class pulse : WebSocketBehavior
	{
		int connectedClients = 0;
		protected override void OnOpen()
		{
			base.OnOpen();
			Form1.F1.WebSocketConnected();
			connectedClients++;
		}

		protected override void OnClose(CloseEventArgs e)
		{
			base.OnClose(e);
			if (connectedClients == 0)
			{
				Form1.F1.WebSocketDisConnected();
			}
		}
	}

	public class tourenyState : WebSocketBehavior
	{
		protected override void OnOpen()
		{
			base.OnOpen();
		}
	}
	static class Program
	{
		/// <summary>
		/// 해당 애플리케이션의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(args.FirstOrDefault()));
		}
	}

	public class chat : WebSocketBehavior
	{
		protected override void OnOpen()
		{
			base.OnOpen();
		}

		protected override void OnClose(CloseEventArgs e)
		{
			base.OnClose(e);
		}
	}
}
