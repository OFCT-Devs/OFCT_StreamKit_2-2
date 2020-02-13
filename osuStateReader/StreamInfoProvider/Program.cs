using System;
using System.Linq;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace osuStateReader
{
	public class pulse : WebSocketBehavior
	{
		int count = 0;
		protected override void OnOpen()
		{
			base.OnOpen();
			count++;
			Form1.F1.WebSocketConnected(0);
		}

		protected override void OnClose(CloseEventArgs e)
		{
			base.OnClose(e);
			count--;
			if (count == 0)
			{
				Form1.F1.WebSocketDisconnected(0);
			}
		}
	}

	public class tourenyState : WebSocketBehavior
	{
		int count = 0;
		protected override void OnOpen()
		{
			base.OnOpen();
			count++;
			Form1.F1.WebSocketConnected(1);
		}

		protected override void OnClose(CloseEventArgs e)
		{
			base.OnClose(e);
			count--;
			if (count == 0)
			{
				Form1.F1.WebSocketDisconnected(1);
			}
		}
	}

	public class chat : WebSocketBehavior
	{
		int count = 0;
		protected override void OnOpen()
		{
			base.OnOpen();
			count++;
			Form1.F1.WebSocketConnected(2);
		}

		protected override void OnClose(CloseEventArgs e)
		{
			base.OnClose(e);
			count--;
			if (count == 0)
			{
				Form1.F1.WebSocketDisconnected(2);
			}
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
}
