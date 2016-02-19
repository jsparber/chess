using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Cairo;
using Gtk;
using Gdk;

namespace Chess
{
  public class svg : DrawingArea
  {
    private ImageSurface src;

    private static string GetEmptyPath ()
    {
      string bpath = "temp", path = "temp";
      for (int i = 0; File.Exists (path); i++)
        path = bpath + i.ToString ();
      return path;
    }

    public svg (string file, coord size)
    {
      Gdk.Pixbuf display = new Pixbuf ("/home/julian/Projects/Chess/Chess/Chess/img/cburnett/" + file + ".svg", size.x, size.y);
 
      string tempname = GetEmptyPath ();
 
      display.Save (tempname, "png");
      //byte[] cache = display.SaveToBuffer("png");
 
      //ImageSurface img = new ImageSurface (cache, Format.ARGB32, 500, 500, 2000);
      ImageSurface img = new ImageSurface (tempname);
      File.Delete (tempname);
      //w.Resize (img.Width, img.Height);
      //DrawingArea a = new svg (img);
      this.src = img;
      //Box box = new HBox (true, 0);
      //box.Add (a);
      //w.Add (box);
      //a.ShowAll ();
    }

    protected override bool OnExposeEvent (Gdk.EventExpose args)
    {
      using (Context c = Gdk.CairoHelper.Create (args.Window)) {
        c.SetSource (new SurfacePattern (src));
        //c.SetSourceRGBA (0, 0, 0, 0);
        c.Paint ();
      }
      return true;
    }
  }
}