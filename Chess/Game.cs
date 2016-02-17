using System;
using System.Collections.Generic;

namespace Chess
{
	public class Game
	{
    const string layout = "RNBQKBNR\n" +
                   "PPPPPPPP\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "pppppppp\n" +
                   "rnbqkbnr";

    private Figure[,] board;
    private List<Figure> removedFigures;
    private Player[] player;

 
    //constructor
    public Game ()
		{
      removedFigures = new List<Figure> ();
      this.board = fillBoard ();
      this.player = new Player[2];
      this.player [0] = new Player ("white");
      this.player [1] = new Player ("black");
		}

    //fills the board with layout
    private Figure[,] fillBoard () {
      Figure [,] board;

      int noLine = 1;  // is 1 because the last line dosen't have a \n
      int lineLength = 0;
      for (int i = 0; i < layout.Length; i++) {
        if (layout [i] == '\n') {
          noLine++;
        }
        else
          lineLength++;
      }
      lineLength /= noLine;

      board = new Figure[lineLength, noLine];

      int c = 0;
      for (int x = 0; x < lineLength; x++) {
        for (int y = 0; y < noLine; y++) {
          if (layout [c] == '\n')
            c++;
          board [x, y] = figureLookup (layout [c]);
          c++;
        }
      }
      return board;
    }

    public Figure figureLookup (char c) {
      Figure result;
      string color = "white";
      if (Char.IsLower (c)) {
        c = Char.ToUpper (c);
        color = "black";
      }
      switch (c) {
      case 'R':
        result = new Rock (color);
        break;
      case 'N':
        result = new Knight (color);
        break;
      case 'B':
        result = new Bishop (color);
        break;
      case 'Q':
        result = new Queen (color);
        break;
      case 'K':
        result = new King (color);
        break;
       case 'P':
        result = new Pawn (color);
        break;
      default:
        result = new Empty ();
        break;
      }
      return result;
    }

    public Figure[,] getBoard() {
      return this.board;
    }
    //prints the board to the log used for debuging
    public void printBoard () {
      for (int x = 0; x < 8; x++) {
        for (int y = 0; y < 8; y++) {
          Console.Write (this.board [x, y].GetType ().Name + " ");
        }
        Console.WriteLine ("");
      }
      Console.Clear ();
    }
   
    //returns true if the move is possible
    //retruns false if the move is not possible
    private bool checkMove(string color, coord start, coord end) {
      if ((this.board[start.x, start.y].GetType().Name == "Empty") &&
        (this.board[start.x, start.y].getColor != color) &&
        (this.board[end.x, end.y].getColor == color))
          return false; 

      return this.board [start.x, start.y].move (this.board, start, end);
    }

    public bool move (string color, coord start, coord end) {
      if (checkMove(color, start, end)) {
        if (this.board [end.x, end.y].GetType ().Name != "Empty") {
          removedFigures.Add (this.board [end.x, end.y]);
        }
        this.board[end.x, end.y] = this.board[start.x, start.y];
        this.board[start.x, start.y] = new Empty();
        return true;
      }
      else {
        return false;
      }
    }

	}
}

