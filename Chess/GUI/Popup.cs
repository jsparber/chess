using System;
using Gtk;

namespace Chess
{
  public class Popup: Gtk.Window
  {
    private HBox box;
    private Figure[] figures;
    private Action<string, coord> callback;
    private coord tileSize;

    public Popup (Window parent, Figure[] f, Action<string, coord> callback, int scale) : base (Gtk.WindowType.Toplevel)
    {
      this.TransientFor = parent;
      this.SetPosition(Gtk.WindowPosition.CenterOnParent);
      this.callback = callback;
      this.Title = "choose";
      this.figures = f;
      this.Decorated = false;
      this.box = new HBox ();
      this.Add (this.box);
      this.tileSize = new coord (10 * scale, 10 * scale);
    }

    public void open(Player player, coord position) {
     close ();
     foreach (Figure fig in this.figures) {
        TileWidget tile = new TileWidget ("", fig.GetType ().Name, player.ToString() , this.tileSize);
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
