using System;
using Gtk;

namespace Chess
{
  public partial class GridWidget : Table
  {
    private Game game;
    private Graphics gui;

    private coord clickedPosition;

    private bool clicked;

    public GridWidget (Game g , Graphics gui) : base ((uint)((Game)g).getSize().x, (uint)((Game)g).getSize().y, true)
    {
      this.clicked = false;
      this.game = g;
      this.gui = gui;
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
      for (int x = 0; x < this.game.getSize ().x; x++) {
        tileBackground = (tileBackground == "white") ? "gray" : "white";
        for (int y = 0; y < this.game.getSize ().y; y++) {
          string type = this.game.getFieldName (new coord (x, y));
          string playerColor = this.game.getFieldColor (new coord (x, y));
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

    private void updateBoard ()
    {
      //remove all children
      foreach (Widget child in this.Children) {
        child.Destroy ();
      }
      //add all children
      createBoard();
    }

    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      TileWidget tile = (TileWidget)obj;
      //Console.WriteLine (tile.position.x + ", " + tile.position.y + " " + tile.color + " " + tile.figure);
      if (!this.clicked) {
        this.clickedPosition = new coord (tile.position.x, tile.position.y);
        //check if there is something to move on the clicked tile
        if (!this.game.Move (new coord (this.clickedPosition.x, this.clickedPosition.y)).error) {
          this.clicked = true;
          Image circle = tile.loadCircle (new coord (100, 100));
          Fixed f = (Fixed)(tile.Child);
          f.Add (circle);
          f.ShowAll ();
        }
      } else {
        Message msg = this.game.Move (new coord (this.clickedPosition.x, this.clickedPosition.y), new coord (tile.position.x, tile.position.y));
        this.clicked = false;
        updateBoard ();
        gui.updateGui (msg);
      }
    }
  }
}

