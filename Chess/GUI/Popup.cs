using System;
using Gtk;

namespace Chess
{
  // class for the popup when the pawn have to be promoted
  public class Popup: Gtk.Window
  {
    private HBox box;
    private Figure[] figures;
    private Action<Figure, coord> callback;
    private coord tileSize;

    // constructor
    public Popup (Window parent, Figure[] f, Action<Figure, coord> callback, int scale) : base (Gtk.WindowType.Toplevel)
    {
      this.TransientFor = parent;
      this.SetPosition (Gtk.WindowPosition.CenterOnParent);
      this.Decorated = false;

      this.tileSize = new coord (10 * scale, 10 * scale);
      this.callback = callback;
      this.Title = "choose";
      this.figures = f;
      this.box = new HBox ();
      this.Add (this.box);
    }

    // Method for the opening of popup
    public void open (Player player, coord position)
    {
      close ();
      foreach (Figure fig in this.figures) {
        TileWidget tile = new TileWidget ("", fig.name (), player.ToString (), this.tileSize);
        tile.position = position;
        fig.color = player.ToString ();
        box.PackStart (tile);
        tile.ButtonPressEvent += onTileClicked;
      }
      this.ShowAll ();
    }

    // Method for the closing of the popup
    private void close ()
    {
      foreach (Widget child in this.box.Children) {
        child.Destroy ();
      }
      this.Hide ();
    }

    // Method that describe the reaction of a tile when it is clicked
    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      TileWidget tile = (TileWidget)obj;
      bool found = false;
      for (int i = 0; i < ((HBox)tile.Parent).Children.Length && !found; i++) {
        if (((HBox)tile.Parent).Children [i].Equals (tile)) {
          found = true;
          this.callback (this.figures [i], tile.position);
        }
      }
      close ();
    }
  }
}
