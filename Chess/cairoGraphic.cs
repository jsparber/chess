using System;
using Gtk;
using Cairo;

namespace Chess
{
  public class CairoGraphic : DrawingArea
  {
    protected override bool OnExposeEvent (Gdk.EventExpose args)
    {
      using (Context g = Gdk.CairoHelper.Create (args.Window)){
        g.Arc (50, 50, 40, 0, 2 * Math.PI);

        g.Color = new Color (0, 0, 0);
        g.LineWidth = 5;
        g.Stroke ();
      }
      return true;
    }
  }
}

