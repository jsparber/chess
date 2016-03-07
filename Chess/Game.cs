using System;
using System.Collections.Generic;

namespace Chess
{
	public class Game
	{
 
    public Board board { get; }
    private string currentPlayer { get; set; }

    public Game ()
		{
      this.board = new Board ();
      this.currentPlayer = "white";
		}
    

    public coord getSize() {
      return this.board.size;
    }

    public Message Move(coord start, coord end) {
      Message msg = this.board.Move (this.currentPlayer, start, end);
      if (!msg.error) {
        tooglePlayer ();
      }
      msg.player = this.currentPlayer;
      return msg;
    }

    public Message Move(coord start) {
      return new Message(this.board.getFieldFigureName(start) == "Empty", "firstClick", "", "");
    }

    private void tooglePlayer() {
      this.currentPlayer = (this.currentPlayer == "white") ? "black" : "white";
    }

    public List<Figure> getRemovedFigures() {
      return this.board.removedFigures;
    }
	}
}

