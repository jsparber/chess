using System;
using System.Collections.Generic;

namespace Chess
{
	public class Game
	{
 
    private Board board;
    private Player[] player;
    private string currentPlayer { get; set; }

 
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
      return getField (c).GetType ().Name;
    }
    public string getFieldColor(coord c) {
      return getField(c).getColor;
    }
    public Figure getField(coord c) {
      return this.board.fields [c.x, c.y];
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

    public Board getBoard() {
      return this.board;
    }

    public coord getSize() {
      return this.board.size;
    }

    public bool Move(coord start, coord end) {
      bool res = this.board.Move (this.currentPlayer, start, end);
      if (res)
        tooglePlayer ();
      return res;
    }

    public bool Move(coord start) {
      return (this.getFieldName(start) != "Empty");
    }

    private void tooglePlayer() {
      this.currentPlayer = (this.currentPlayer == "white") ? "black" : "white";
    }

    public List<Figure> getRemovedFigures() {
      return this.board.removedFigures;
    }
	}
}

