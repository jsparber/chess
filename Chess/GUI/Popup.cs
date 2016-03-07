using System;
using Gtk;

namespace Chess
{
  public class Popup: Gtk.Window
  {
    public Popup () : base (Gtk.WindowType.Toplevel)
    {
      this.Title = "chooser";
      //popup.Resizable = false;
      this.Decorated = false;
      this.Resize (100, 100);
      HBox box2 = new HBox ();
      box2.PackStart (new TileWidget ("", "Queen", "black", new coord (100, 100)));
      box2.PackStart (new TileWidget ("", "Pawn", "black", new coord (100, 100)));
      this.Add (box2);
      this.ShowAll ();
    }
  }
}
