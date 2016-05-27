using System;
using Gtk;

namespace Chess
{
  public partial class GridWidget : Table
  {
    //public delegate bool Cb(coord start, coord end);
    private Game game;                // Istance of game class
    private Cb callback;              // Delegate method 
    private coord clickedPosition;    // coord of clicked position
    private bool clicked;             // true if a tile is clicked
    private coord tileSize;           // Size of a tile

    // Constructor
    public GridWidget (Game game, Cb callback, int scale) : base ((uint)game.getSize ().x, (uint)game.getSize ().y, true)
    {
      this.callback = callback;
      this.clicked = false;
      this.game = game;
      this.tileSize = new coord (10 * scale, 10 * scale);
    }

    // Method for adding a figure to game
    private void addFigure (Widget w, coord pos)
    {
      this.Attach (w, (uint)pos.x, (uint)pos.x + 1, (uint)pos.y, (uint)pos.y + 1);
    }

    // Method that draw the board
    private void createBoard ()
    {
      //alternating background color for the grid
      string tileBackground = "white";
      for (int x = 0; x < this.game.getSize ().x; x++) {
        tileBackground = (tileBackground == "white") ? "gray" : "white";
        for (int y = 0; y < this.game.getSize ().y; y++) {
          string type = this.game.getFieldFigureName (new coord (x, y));
          string playerColor = this.game.getFieldFigureColor (new coord (x, y));
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

    // Method for updating the grid
    public void updateGrid ()
    {
      //remove all children
      foreach (Widget child in this.Children) {
        child.Destroy ();
      }
      //add all children
      createBoard ();
    }

    // Method that describe what happen when a tile is clicked
    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      if (((Gdk.EventButton)args.Event).Type == Gdk.EventType.ButtonPress) {
        TileWidget tile = (TileWidget)obj;
        //Console.WriteLine (tile.position.x + ", " + tile.position.y + " " + tile.color + " " + tile.figure);
        if (!this.clicked) {
          this.clickedPosition = new coord (tile.position.x, tile.position.y);

          if (this.callback (this.clickedPosition, this.clickedPosition)) {
            this.clicked = true;
            Fixed f = (Fixed)(tile.Child);
            Image circle = tile.loadCircle (this.tileSize);
            f.Add (circle);
            f.ShowAll ();
          }
        } else {
          //remove the ring whenn the user clicks agen on the same tile
          if (this.callback (this.clickedPosition, tile.position) &&
              this.clickedPosition.Equals (tile.position)) {
            Fixed f = (Fixed)(tile.Child);
            if (f.Children.Length > 1)
              f.Remove (f.Children [1]);
          }
          this.clicked = false;
        }
      }
    }
  }
}