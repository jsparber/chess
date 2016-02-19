using System;
using System.Collections.Generic;

namespace Chess
{
  public class Board
  {

    //game start layout of the board
    //lower case is black
    //X or any char differnt than rnbqkp is considered empty
    const string layout = "RNBQKBNR\n" +
                         "PPPPPPPP\n" +
                         "XXXXXXXX\n" +
                         "XXXXXXXX\n" +
                         "XXXXXXXX\n" +
                         "XXXXXXXX\n" +
                         "pppppppp\n" +
                         "rnbkqbnr";

    public Figure[,] fields { get; set; }

    public coord size { get; set; }

    private List<Figure> removedFigures;

    public Board ()
    {
      removedFigures = new List<Figure> ();
      int noLine = 1;  // is 1 because the last line dosen't have a \n
      int lineLength = 0;
      for (int i = 0; i < layout.Length; i++) {
        if (layout [i] == '\n') {
          noLine++;
        } else
          lineLength++;
      }
      lineLength /= noLine;

      //create array with the right size
      this.fields = new Figure[lineLength, noLine];
      //save size
      this.size = new coord (lineLength, noLine);

      //fill up the array with the right figures
      int c = 0;
      for (int y = 0; y < noLine; y++) {
        for (int x = 0; x < lineLength; x++) {
          if (layout [c] == '\n')
            c++;
          this.fields [x, y] = figureLookup (layout [c]);
          c++;
        }
      }
    }

    private Figure figureLookup (char c)
    {
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


    public bool Move (string color, coord start, coord end)
    {
      if (checkMove (color, start, end)) {
        if (this.fields [end.x, end.y].GetType ().Name != "Empty") {
          this.removedFigures.Add (this.fields [end.x, end.y]);
        }
        this.fields [end.x, end.y] = this.fields [start.x, start.y];
        this.fields [start.x, start.y] = new Empty ();
        return true;
      } else {
        return false;
      }
    }
    //returns true if the move is possible
    //retruns false if the move is not possible
    private bool checkMove (string color, coord start, coord end)
    {
      if ((this.fields [start.x, start.y].GetType ().Name == "Empty") ||
          (this.fields [start.x, start.y].getColor != color) ||
          (this.fields [end.x, end.y].getColor == color))
        return false; 

      return this.fields [start.x, start.y].move (this.fields, start, end);
    }
  }
}

