using System;
using Gtk;

namespace Chess
{
	class MainClass
	{
		public static void Main (string[] args)
		{
      Game g = new Game ();
      g.printBoard ();
      Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
     
		}
	}
}
