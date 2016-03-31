using System;

namespace Chess
{
  /* Class for the player */
  public class Player
  {
    private string currentPlayer;         /* String identifiyng color of actual player */

    /* Constructor of the player object */
    public Player (string player)
    {
      this.currentPlayer = player;
    }

    /* Override of 'ToString' method */
    public override string ToString ()
    {
      return currentPlayer;                /* It returns the string that represent color of actual player */
    }

    /* Method for the alternance of players */
    public Player next ()
    {
      /* If current player is white next will be black and vice-versa */
      return new Player ((this.currentPlayer == "white") ? "black" : "white");
    }
  }
}