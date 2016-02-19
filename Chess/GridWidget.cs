using System;
using Gtk;

namespace Chess
{
  public partial class GridWidget : Table
  {
    public Game game { get; set; }
    public coord clickedPosition { get; set; }
    public bool clicked { get; set; }
    public GridWidget (Game g, coord size) : base ((uint)size.x, (uint)size.y, true)
    {
      this.clicked = false;
      this.game = g;
    }

    public void addFigure (Widget w, coord pos)
    {
      this.Attach (w, (uint)pos.x, (uint)pos.x + 1, (uint)pos.y, (uint)pos.y + 1);
    }
  }
}

