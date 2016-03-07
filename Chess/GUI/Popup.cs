using System;
using Gtk;

namespace Chess
{
  public class Popup: Gtk.Window
  {
    public Popup (Figure[] figures) : base (Gtk.WindowType.Popup)
    {
      this.Title = "chooser";
      //popup.Resizable = false;
      //this.Decorated = false;
      this.DefaultHeight = 100;
      this.DefaultWidth = 100;
      HBox box = new HBox ();
      foreach (Figure fig in figures) {
        TileWidget tile = new TileWidget ("", fig.GetType ().Name, fig.color, new coord (100, 100));
        box.PackStart (tile);
        tile.ButtonPressEvent += onTileClicked;
      }
      this.Add (box);
      this.ShowAll ();
      this.Show ();
    }

    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      //TileWidget tile = (TileWidget)obj;
      Console.WriteLine ("Clicled");
      //this.Quit ();
      this.Destroy ();
    }
  }
}
