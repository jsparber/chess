using System;

namespace Chess
{
	public class Game
	{
    private char[,] board;
    const string layout = "RNBQKBNR\n" +
                   "PPPPPPPP\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "XXXXXXXX\n" +
                   "pppppppp\n" +
                   "rnbqkbnr";

 
    //constructor
    public Game ()
		{
      this.board = fillBoard ();
		}

    //fills the board with layout
    private char[,] fillBoard () {
      char [,] board;

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

      board = new char[lineLength, noLine];

      int c = 0;
      for (int x = 0; x < lineLength; x++) {
        for (int y = 0; y < noLine; y++) {
          if (layout [c] == '\n')
            c++;
          board [x, y] = layout [c];
          c++;
        }
      }
      return board;
    }
    //prints the board to the log used for debuging
    public void printBoard () {
      for (int x = 0; x < 8; x++) {
        for (int y = 0; y < 8; y++) {
          Console.Write (this.board [x, y]);
        }
        Console.WriteLine ("");
      }
    }
	}
}

