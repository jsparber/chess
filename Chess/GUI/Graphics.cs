﻿using System;
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

    // constructor that show the graphic interface to users
    public Graphics (Game g) : base (Gtk.WindowType.Toplevel)
    {
      Build ();
      int scale = 10;
      if (Screen.Height < 1000)
        scale = 5;
      this.game = g;
      VBox gridWrapper = new VBox ();
      HBox box = new HBox ();
      this.status = new Label ("");
      this.chooser = new Popup (this, this.game.getChooseableFigures(), handleChooser, scale);
      this.mainGrid = new GridWidget (this.game, clickHandler, scale);
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

    // method for updating of graphic interface
    public void updateGui (Message msg)
    {
      this.sidebarLeft.updateSidebar ();
      this.sidebarRight.updateSidebar ();
      this.mainGrid.updateGrid ();
      if (msg.error == false && msg.format () != "")
        this.status.Text = msg.format ();
      msg.print ();
   
    }

    // Method for delete an event
    protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    {
      Application.Quit ();
      a.RetVal = true;
    }

    // Method that build the graphics of the game
    protected virtual void Build ()
    {
      global::Stetic.Gui.Initialize (this);
      // Widget Chess.MainWindow
      this.Name = "Chess.MainWindow";
      this.Title = "Chess";
      this.WindowPosition = ((global::Gtk.WindowPosition)(3));
      this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
    }

    // Method for handling the click
    public bool clickHandler (coord start, coord end)
    {
      Message msg;
      if (start.Equals (end)) {
        msg = this.game.call(new Payload (false, "checkSelection", start));
      } else {
        msg = this.game.call(new Payload(false, "move", start, end));
        if (msg.action == "chooser") {
          this.chooser.open (msg.player, end);
        }
        updateGui (msg);
      }
      return !msg.error;
    }

    // Method for handling the chooser
    public void handleChooser (Figure figure, coord position)
    {
      updateGui (this.game.call (new Payload (false, "switchFigures", figure, position)));
    }

  }
}