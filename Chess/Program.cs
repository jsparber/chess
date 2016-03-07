using System;
using Gtk;

namespace Chess
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Application.Init ();

      //creates the game
      Game g = new Game ();

      //creates the gui for the Game g
      //Graphics gui = new Graphics (g);
      new Graphics (g);
      Application.Run ();
     
    }
  }
}
