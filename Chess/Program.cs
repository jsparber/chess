using System;
using Gtk;

namespace Chess
{
	class MainClass
	{
		public static void Main (string[] args)
		{
      Game g = new Game ();
      Application.Init ();
			MainWindow win = new MainWindow ();
      win.Show ();

      Label output = new Label();
      //coord c = g.getSize ();
      output.Text = g.printBoard ();
      win.Add(output);
      win.ShowAll();
      coord start = new coord ();
      coord end = new coord ();

      start.x = 1;
      start.y = 1;
      end.x = 2;
      end.y = 4;
      Console.WriteLine (
        g.move ("white", start, end));
      output.Text = g.printBoard ();
			Application.Run ();
     
		}
	}
}
