using System;
using Gtk;

namespace Chess
{
  public partial class GridWidget : Table
  {
    //public delegate bool Cb(coord start, coord end);
    private Board board;
    private Cb callback;

    private coord clickedPosition;

    private bool clicked;

    public GridWidget (Board board, Cb callback) : base ((uint)board.getSize ().x, (uint)board.getSize ().y, true)
    {
      this.callback = callback;
      this.clicked = false;
      this.board = board;
      createBoard ();
    }

    private void addFigure (Widget w, coord pos)
    {
      this.Attach (w, (uint)pos.x, (uint)pos.x + 1, (uint)pos.y, (uint)pos.y + 1);
    }

    private void createBoard ()
    {
      //alternating background color for the grid
      string tileBackground = "white";
      for (int x = 0; x < this.board.getSize ().x; x++) {
        tileBackground = (tileBackground == "white") ? "gray" : "white";
        for (int y = 0; y < this.board.getSize ().y; y++) {
          string type = this.board.getFieldFigureName (new coord (x, y));
          string playerColor = this.board.getFieldFigureColor (new coord (x, y));
          tileBackground = (tileBackground == "white") ? "gray" : "white";

          type = (type == "Empty") ? "" : type;
          TileWidget tile = new TileWidget (tileBackground, type, playerColor, new coord (100, 100));
          tile.position = new coord (x, y);
          tile.ButtonPressEvent += onTileClicked;
          this.addFigure (tile, new coord (x, y));
        }
      }
      this.ShowAll ();
    }

    public void updateGrid ()
    {
      //remove all children
      foreach (Widget child in this.Children) {
        child.Destroy ();
      }
      //add all children
      createBoard ();
    }

    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      TileWidget tile = (TileWidget)obj;
      //Console.WriteLine (tile.position.x + ", " + tile.position.y + " " + tile.color + " " + tile.figure);
      if (!this.clicked) {
        this.clickedPosition = new coord (tile.position.x, tile.position.y);
        //check if there is something to move on the clicked tile
        if (this.callback (this.clickedPosition, this.clickedPosition)) {
          this.clicked = true;
          Image circle = tile.loadCircle (new coord (100, 100));
          Fixed f = (Fixed)(tile.Child);
          f.Add (circle);
          f.ShowAll ();
        }
      } else {
        this.callback (new coord (this.clickedPosition.x, this.clickedPosition.y), new coord (tile.position.x, tile.position.y));
        this.clicked = false;
      }
  }
  }
}

