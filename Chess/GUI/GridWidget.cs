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
    private coord tileSize;

    public GridWidget (Board board, Cb callback, int scale) : base ((uint)board.getSize ().x, (uint)board.getSize ().y, true)
    {
      this.callback = callback;
      this.clicked = false;
      this.board = board;
      this.tileSize = new coord (10 * scale, 10 * scale);
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
          TileWidget tile = new TileWidget (tileBackground, type, playerColor, this.tileSize);
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

        if (this.callback (this.clickedPosition, this.clickedPosition)) {
          this.clicked = true;
          Image circle = tile.loadCircle (this.tileSize);
          Fixed f = (Fixed)(tile.Child);
          f.Add (circle);
          f.ShowAll ();
        }
      } else {
        this.callback (this.clickedPosition, tile.position);
        if (this.clickedPosition.Equals (tile.position)) {
          updateGrid ();
        }
        this.clicked = false;
      }
  }
  }
}

