using System;
using System.Collections.Generic;

namespace Chess
{
	public class Game
	{
 
    private Board board;
    private Player[] player;
    private string currentPlayer { get; }

 
    //constructor
    public Game ()
		{
      this.board = new Board ();
      this.currentPlayer = "white";
      this.player = new Player[2];
      this.player [0] = new Player ("white");
      this.player [1] = new Player ("black");
		}
    
    public string getFieldName(coord c) {
      return (this.board.fields [c.x, c.y].GetType ().Name);
    }
 
    //prints the board to the log used for debuging
    public string printBoard () {
      string output = "";
      for (int x = 0; x < 8; x++) {
        for (int y = 0; y < 8; y++) {
          output += getFieldName (new coord (x, y));
        }
        output += "\n";
      }
      return output;
    }
    public coord getSize() {
      return this.board.size;
    }

    public bool move(coord start, coord end) {
      return this.board.Move (this.currentPlayer, start, end);
    }

    private string tooglePlayer() {
      return (this.currentPlayer == "white") ? "black" : "white";
    }
	}
}

