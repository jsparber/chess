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
      //win.Resize (800, 800);
      //win.Decorated = false;
      win.Show ();
      //g.move (new coord(0,0), new coord(2,3));
      win.Add (createBoard (g));
      win.ShowAll ();
      Application.Run ();
     
    }

    private static Table createBoard (Game g)
    {
      GridWidget chessBoard = new GridWidget (g, g.getSize ());
      //Gdk.Pixbuf display = new Pixbuf ("/home/julian/Projects/Chess/Chess/Chess/img/cburnett/bB.svg", 100, 100);
      string colorBg = "white";
      for (int x = 0; x < g.getSize ().x; x++) {
          colorBg = (colorBg == "white") ? "gray" : "white";
        for (int y = 0; y < g.getSize ().y; y++) {
          string title = g.getFieldName (new coord ((int)x, (int)y));
          string color = g.getFieldColor (new coord ((int)x, (int)y));
          colorBg = (colorBg == "white") ? "gray" : "white";

          title = (title == "Empty") ? "" : title;
          FieldWidget field = new FieldWidget (colorBg, title, color);
          field.position = new coord ((int)x, (int)y);
          field.ButtonPressEvent += onFieldClick;
          chessBoard.addFigure (field, new coord (x, y));
          //chessBoard.Add(display);
        }
      }
      chessBoard.ShowAll ();
      return chessBoard;
    }

    private static void updateBoard (GridWidget grid)
    {
      MainWindow parent = (MainWindow)grid.Parent;
      Game g = grid.game;
      grid.Destroy ();
      parent.Add(createBoard(g));
    }

    static void onFieldClick (object obj, ButtonPressEventArgs args)
    {
      FieldWidget field = (FieldWidget)obj;
      GridWidget parent = (GridWidget)field.Parent;
      Game g = (Game)parent.game;
      Console.WriteLine (field.position.x + ", " + field.position.y + " " + field.color + " " + field.figure);
      if (!parent.clicked) {
        parent.clickedPosition = new coord (field.position.x, field.position.y);
        parent.clicked = true;
      } else {
        g.move (new coord (parent.clickedPosition.x, parent.clickedPosition.y), new coord (field.position.x, field.position.y));
        parent.clicked = false;
        updateBoard (parent);
      }
    }
  }
}
