using System;

namespace Chess
{
  public class Player
  {
    private string currentPlayer;

    public Player (string player)
    {
      this.currentPlayer = player;
    }

    public override string ToString ()
    {
      return currentPlayer;
    }

    public Player next ()
    {
      return new Player ((this.currentPlayer == "white") ? "black" : "white");
    }
  }
}

