using System;
using Gtk;

namespace Chess
{
  public class Popup: Gtk.Window
  {
    private HBox box;
    private Figure[] figures;
    private Action<string, string> callback;
    public Popup (Figure[] f, Action<string, string> callback) : base (Gtk.WindowType.Toplevel)
    {
      this.callback = callback;
      this.Title = "chooser";
      this.figures = f;
      this.Decorated = true;
      this.DefaultHeight = 100;
      this.DefaultWidth = 100;
      this.box = new HBox ();
      this.Add (this.box);
    }

    public void open(string color, coord position) {
     this.close ();
     foreach (Figure fig in this.figures) {
        TileWidget tile = new TileWidget ("", fig.GetType ().Name, color , new coord (100, 100));
        tile.position = position;
        box.PackStart (tile);
        tile.ButtonPressEvent += onTileClicked;
      }
      this.ShowAll ();
      this.Show ();
    }

    public void close() {
      foreach (Widget child in this.box.Children) {
        child.Destroy ();
      }
      this.Hide ();
    }

    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      TileWidget tile = (TileWidget)obj;
      Console.WriteLine ("Clicled");
      close();
      this.callback (tile.figure, tile.color);
    }
  }
}
