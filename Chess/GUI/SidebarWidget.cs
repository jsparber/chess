using System;
using Gtk;
using System.Collections.Generic;

namespace Chess
{
  public partial class SidebarWidget : Gtk.VBox
  {
    private List<Figure> removedFigures;
    private string color;
    public SidebarWidget (List<Figure> removedFigures, string color)
    {
      this.removedFigures = removedFigures;
      this.color = color;

      updateSidebar ();

      this.WidthRequest = 50;
    }

    public void updateSidebar ()
    {
      foreach (Widget child in this.Children) {
        child.Destroy ();
      }
      foreach (Figure f in removedFigures) {
        if (f.color == this.color) {
          this.PackStart (new TileWidget ("", f.GetType ().Name, f.color, new coord (50, 50)), false, false, 0);
        }
      }
      this.ShowAll ();
    }
  }
}

