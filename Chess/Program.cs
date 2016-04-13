using System;
using Gtk;

namespace Chess
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Application.Init ();
      //Create game
      Game g = new Game ();         
       //Create the graphic interface for the game
      new Graphics (g);         
      Application.Run ();
    }
  }
}