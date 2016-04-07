using System;
using Gtk;

namespace Chess
{
  public delegate bool Cb (coord start, coord end);
  public class Graphics : Gtk.Window
  {
    private GridWidget mainGrid;
    private SidebarWidget sidebarRight;
    private SidebarWidget sidebarLeft;
    private Popup chooser;
    private Label status;
    private Game game;

    public Graphics (Game g) : base (Gtk.WindowType.Toplevel)
    {
      Build ();
      int scale = 10;
      this.game = g;
      VBox gridWrapper = new VBox ();
      HBox box = new HBox ();
      this.status = new Label ("");
      this.chooser = new Popup (g.board.getChooseableFigure (), handleChooser, scale);
      this.mainGrid = new GridWidget (g.board, clickHandler, scale);
      gridWrapper.PackStart (status, false, false, 0);
      gridWrapper.PackStart (this.mainGrid, false, false, 0);
      this.sidebarLeft = new SidebarWidget (g.getRemovedFigures (), "black", scale);
      box.PackStart (new HBox ());
      box.PackStart (this.sidebarLeft);
      box.PackStart (gridWrapper, false, false, 0);
      this.sidebarRight = new SidebarWidget (g.getRemovedFigures (), "white", scale);
      box.PackEnd (this.sidebarRight);
      box.PackStart (new HBox ());
      box.ShowAll ();
      this.Add (box);
      updateGui (this.game.initialState ());
      this.Show ();
    }

    public void updateGui (Message msg)
    {
      this.sidebarLeft.updateSidebar ();
      this.sidebarRight.updateSidebar ();
      this.mainGrid.updateGrid ();
      if (msg.format () != "")
        this.status.Text = msg.format ();
      msg.print ();
   
    }

    public void handleChooser (string figure, coord position)
    {
      updateGui (this.game.board.switchFigures (figure, position));
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
      this.WindowPosition = ((global::Gtk.WindowPosition)(3));
      if ((this.Child != null)) {
        this.Child.ShowAll ();
      }
      this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
    }

    public bool clickHandler (coord start, coord end)
    {
      Message msg;
      if (start.Equals (end)) {
        msg = this.game.Move (start);
      } else {
        msg = this.game.Move (start, end);
        if (msg.action == "chooser") {
          this.chooser.open (msg.player, end);
        }
        updateGui (msg);
      }
      return !msg.error;
    }
  }
}

