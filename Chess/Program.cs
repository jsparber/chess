using System;
using Gtk;

namespace Chess
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Application.Init ();

      Game g = new Game ();      /* Creates a new game */     
   
      new Graphics (g);          /* Creates the graphic interface for the game (g) [ Graphics gui = new Graphics (g); ]*/

      Application.Run ();
     
    }
  }
}