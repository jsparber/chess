using System;
using Gtk;
using System.Collections.Generic;

namespace Chess
{
  public partial class SidebarWidget : Gtk.VBox
  {
    private List<Figure> removedFigures;   // List of removed figures
    private string color;                  // Color of the sidebar's admitted figures
    private coord tileSize;                // Size of tile

    // Constructor
    public SidebarWidget (List<Figure> removedFigures, string color, int scale)
    {
      this.removedFigures = removedFigures;     
      this.color = color;                       // Color of the sidebar's admitted figures

      updateSidebar ();

      this.WidthRequest = 5 * scale;
      this.tileSize = new coord (5 * scale, 5 * scale);
    }

    // Method for updating the sidebar
    public void updateSidebar ()
    {
      foreach (Widget child in this.Children) {
        child.Destroy ();
      }
      foreach (Figure f in removedFigures) {
        if (f.color == this.color) {
          this.PackStart (new TileWidget ("", f.GetType ().Name, f.color, this.tileSize), false, false, 0);
        }
      }
      this.ShowAll ();
    }
  }
}

