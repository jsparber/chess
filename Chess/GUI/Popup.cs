using System;
using Gtk;

namespace Chess
{
  public class Popup: Gtk.Window
  {
    private HBox box;
    private Figure[] figures;
    private Action<string, coord> callback;
    public Popup (Figure[] f, Action<string, coord> callback) : base (Gtk.WindowType.Toplevel)
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

    public void open(Player player, coord position) {
     close ();
     foreach (Figure fig in this.figures) {
        TileWidget tile = new TileWidget ("", fig.GetType ().Name, player.ToString() , new coord (100, 100));
        tile.position = position;
        box.PackStart (tile);
        tile.ButtonPressEvent += onTileClicked;
      }
      this.ShowAll ();
      this.Show ();
    }

    private void close() {
      foreach (Widget child in this.box.Children) {
        child.Destroy ();
      }
      this.Hide ();
    }

    private void onTileClicked (object obj, ButtonPressEventArgs args)
    {
      TileWidget tile = (TileWidget)obj;
      Console.WriteLine ("Clicled");
      this.callback (tile.figure, tile.position);
      close();
    }
  }
}
