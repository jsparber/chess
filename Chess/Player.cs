using System;

namespace Chess
{
  public class Player
  {
    private string color;

    public Player (string color)
    {
      //save my color
      this.color = color;
      //in case the player is white
      if (color == "white") {

      }
      //in case the player is black
      if (color == "black") {
      }
    }

    public string Color {
      get {return color;}
    }
   
    public Boolean move (Figure f, int coorX, int coorY) {
      return false;
    }
  }
}

