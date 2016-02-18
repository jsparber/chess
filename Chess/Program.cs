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

      g.move (new coord(0,0), new coord(2,3));
      win.Add (createBoard (g));
			Application.Run ();
     
		}
    private static Table createBoard(Game g) {
      Table chessBoard = new Table ((uint)g.getSize().x, (uint)g.getSize().y, true);

      for (uint i = 0; i < g.getSize().y; i++) {
        for (uint j = 0; j < g.getSize().x; j++) {
          string title = g.getFieldName (new coord ((int)i, (int)j));
          title = (title == "Empty") ? "" : title;
          EventBox field = new EventBox ();
          field.Show ();
          field.Add(new Label(title));
          field.ButtonPressEvent += onFieldClick;
          chessBoard.Attach (field, j, j + 1, i, i + 1);
        }
      }
      chessBoard.ShowAll ();
      return chessBoard;
    }
    static void onFieldClick( object obj, ButtonPressEventArgs args) {
      EventBox mybutton = (EventBox) obj;
      object o = mybutton.Parent;
                        //Console.WriteLine("Hello again - {0} was pressed", (string) mybutton.Label);
                        // Have to figure out, how to recieve button name
  }
  }
}
