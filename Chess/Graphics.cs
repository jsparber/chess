using System;
using Gtk;

namespace Chess
{
  public partial class Graphics : Gtk.Bin
  {
    private GridWidget mainGrid;
    private SidebarWidget sidebarRight;
    private SidebarWidget sidebarLeft;
    public Graphics (Game g)
    {
      MainWindow win = new MainWindow ();
      VBox gridWrapper = new VBox ();
      HBox box = new HBox ();
      //win.Resize (800, 800);
      //win.Decorated = false;
      this.mainGrid = new GridWidget (g, this);
      gridWrapper.PackStart (new Label("") , false, false, 0);
      gridWrapper.PackStart (this.mainGrid, false, false, 0);
      this.sidebarLeft = new SidebarWidget (g.getRemovedFigures (), "black");
      box.PackStart (new HBox ());
      box.PackStart (this.sidebarLeft);
      box.PackStart (gridWrapper, false, false, 0);
      this.sidebarRight = new SidebarWidget (g.getRemovedFigures (), "white");
      box.PackEnd (this.sidebarRight);
      box.PackStart (new HBox ());
      box.ShowAll ();
      win.Add (box);
      win.Show ();
    }

    public void updateGui() {
      this.sidebarLeft.updateSidebar ();
      this.sidebarRight.updateSidebar ();
    }

  }
}

