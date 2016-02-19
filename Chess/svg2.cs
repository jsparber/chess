using System;
using Gtk;
using Gdk;

namespace Chess
{
  public class svg2 : Gtk.Image
  {

      Gtk.Image img;
    public svg2 (string file, coord size)
    {
      Gdk.Pixbuf display = new Pixbuf ("/home/julian/Projects/Chess/Chess/Chess/img/cburnett/" + file + ".svg", size.x, size.y);
      this.img = new Gtk.Image(display);
      //img.ShowAll ();
    }
  }
}