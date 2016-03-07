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

    public Message Move(coord start, coord end) {
      Message msg = this.board.Move (this.currentPlayer, start, end);
      msg.player = this.currentPlayer;
      if (!msg.error) {
        tooglePlayer ();
      }
      return msg;
    }

    public Message Move(coord start) {
      return new Message(this.board.getFieldFigureName(start) == "Empty" || this.board.getFieldFigureColor(start) != this.currentPlayer, "firstClick", "", this.currentPlayer);
    }

    private void tooglePlayer() {
      this.currentPlayer = (this.currentPlayer == "white") ? "black" : "white";
    }

    public List<Figure> getRemovedFigures() {
      return this.board.removedFigures;
    }
	}
}

