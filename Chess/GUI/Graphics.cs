using System;
using Gtk;

namespace Chess
{
  public class Graphics : Gtk.Window
  {
    private GridWidget mainGrid;
    private SidebarWidget sidebarRight;
    private SidebarWidget sidebarLeft;
    private Label status;
    public Graphics (Game g) : base (Gtk.WindowType.Toplevel)
    {
      //MainWindow win = new MainWindow ();
      VBox gridWrapper = new VBox ();
      HBox box = new HBox ();
      //win.Resize (800, 800);
      //win.Decorated = false;
      this.status = new Label ("");
      this.mainGrid = new GridWidget (g, this);
      gridWrapper.PackStart (status , false, false, 0);
      gridWrapper.PackStart (this.mainGrid, false, false, 0);
      this.sidebarLeft = new SidebarWidget (g.getRemovedFigures (), "black");
      box.PackStart (new HBox ());
      box.PackStart (this.sidebarLeft);
      box.PackStart (gridWrapper, false, false, 0);
      this.sidebarRight = new SidebarWidget (g.getRemovedFigures (), "white");
      box.PackEnd (this.sidebarRight);
      box.PackStart (new HBox ());
      box.ShowAll ();
      this.Add (box);
      updateGui(new Message(false, "", "", "white"));
      Build ();
    }

    public void updateGui(Message msg) {
      this.sidebarLeft.updateSidebar ();
      this.sidebarRight.updateSidebar ();
      if (msg.format() != "")
        this.status.Text = msg.format ();
      if (msg.action == "chooser") {
      }
      msg.print ();
   
    }

    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
      Application.Quit ();
      a.RetVal = true;
    }

    protected virtual void Build ()
    {
      global::Stetic.Gui.Initialize (this);
      // Widget Chess.MainWindow
      this.Name = "Chess.MainWindow";
      this.Title = global::Mono.Unix.Catalog.GetString ("Chess");
      this.WindowPosition = ((global::Gtk.WindowPosition)(4));
      if ((this.Child != null)) {
        this.Child.ShowAll ();
      }
      this.DefaultWidth = 800;
      this.DefaultHeight = 800;
      this.Show ();
      this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
    }
  }
}

