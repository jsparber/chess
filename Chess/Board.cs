using System;
using System.Collections.Generic;

namespace Chess
{
  public class Board
  {

    //game start layout of the board
    //lower case is black
    //X or any char differnt than rnbqkp is considered empty
    const string layout = "RNBKQBNR\n" +
                          "PPPPPPPP\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "pppppppp\n" +
                          "rnbkqbnr";
    /*const string layout = "RXXKXXXR\n" +
                          "xxxxxxxx\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "xxxxxxxx\n" +
                          "rxxkxxxr";
*/
    public Figure[,] fields { get; set; }

    public coord size { get; set; }

    public List<Figure> removedFigures { get; set; }

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


    public Message Move (string color, coord start, coord end)
    {
      bool isCastling = false;
      Message result = new Message (false, "");
      if (this.getFieldFigure (start) == "King" && this.fields [start.x, start.y].getColor == color) {
        isCastling = doCastling (color, start, end);
        if (isCastling) {
          result.error = false;
          return result;
        }
      }
      if (checkMove (color, start, end)) {
        //check if the king will be in check  after this move and don't allow it if it is
        if (!isCheck (color, start, end)) {
          if (this.fields [end.x, end.y].GetType ().Name != "Empty") {
            this.removedFigures.Add (this.fields [end.x, end.y]);
          }
          this.fields [end.x, end.y] = this.fields [start.x, start.y];
          this.fields [start.x, start.y] = new Empty ();

          //check if with this move the other player will be in check or even checkmate
          string opColor = (color == "white") ? "black" : "white";
          if (isCheck (opColor)) {
            result.msg = "check";
            if (isCheckMate (opColor, new coord (0, 0))) {
              result.msg = "checkmate";
            }
          }
          this.fields [end.x, end.y].hasMoved = true;
          return result;
        }
      } 
      result.error = true;
      return result;
    }
    //returns true if the move is possible
    //retruns false if the move is not possible
    private bool checkMove (string color, coord start, coord end)
    {
      if ((this.fields [start.x, start.y].GetType ().Name == "Empty") ||
          (this.fields [start.x, start.y].getColor != color) ||
          (this.fields [end.x, end.y].getColor == color))
        return false; 

      return this.fields [start.x, start.y].move (this, start, end);
    }

    private bool isCheck (string player, coord start, coord end)
    {
      coord king = new coord ();
      bool noKing = true;
      Figure removedObj = new Figure ();
      bool res = false;
      if (!start.Equals (end)) {
        removedObj = this.fields [end.x, end.y];
        this.fields [end.x, end.y] = this.fields [start.x, start.y];
        this.fields [start.x, start.y] = new Empty ();
      }
      for (int x = 0; x < this.size.x; x++) {
        for (int y = 0; y < this.size.y; y++) {
          if (this.fields [x, y].getColor == player && getFieldFigure (new coord (x, y)) == "King") {
            king = new coord (x, y);
            noKing = false;
          }
        }
      }
      if (!noKing) {
        for (int x = 0; x < this.size.x && !res; x++) {
          for (int y = 0; y < this.size.y && !res; y++) {
            //if a move is posiblie means the king is checked
            if (checkMove ((player == "white") ? "black" : "white", new coord (x, y), king))
              res = true;
          }
        }
      }
      if (!start.Equals (end)) {
        this.fields [start.x, start.y] = this.fields [end.x, end.y]; 
        this.fields [end.x, end.y] = removedObj;
      }
      return res;
    }

    private bool isCheck (string player)
    {
      return isCheck (player, new coord (), new coord ()); 
    }

    private bool isCheckMate (string player, coord start)
    {
      bool res = true;
      for (int x = 0; x < this.size.x && res; x++) {
        for (int y = 0; y < this.size.y && res; y++) {
          coord end = new coord (x, y);
          if (checkMove (player, start, end)) {
            //if is still check it return false;
            res = isCheck (player, start, end);
            if (!res)
              Console.WriteLine ("Found soultion");
          } 
        }
      }
      if (res) {
        if (start.x < this.size.x - 1) {
          res = isCheckMate (player, new coord (start.x + 1, start.y));
        } else if (start.y < this.size.y - 1) {
          res = isCheckMate (player, new coord (0, start.y + 1));
        }
      }
      return res;
    }

    //special moves castling
    public bool doCastling (string player, coord start, coord end)
    {
      if (this.fields [start.x, start.y].hasMoved == false) {
        if (start.x == end.x + 2 && start.x > end.x && !Move (player, start, new coord (start.x - 1, start.y)).error) {
          if (!Move (player, new coord (start.x - 1, start.y), end).error) {
            Figure tmpPosition = this.fields [end.x, end.y];
            this.fields [end.x, end.y] = new Empty ();
            if (!Move (player, new coord (0, start.y), new coord (2, start.y)).error) {
              this.fields [end.x, end.y] = tmpPosition;
              return true;
            } else {
              tmpPosition.hasMoved = false;
              this.fields [start.x, start.y] = tmpPosition;
            }
          } else {
            this.fields [start.x, start.y] = this.fields [start.x - 1, start.y];
            this.fields [start.x, start.y].hasMoved = false;
            this.fields [start.x - 1, start.y] = new Empty ();
          }

        } else if (start.x == end.x - 2 && start.x < end.x && !Move (player, start, new coord (start.x + 1, start.y)).error) {
          if (!Move (player, new coord (start.x + 1, start.y), end).error) {
            Figure tmpPosition = this.fields [end.x, end.y];
            this.fields [end.x, end.y] = new Empty ();
            if (!Move (player, new coord (7, start.y), new coord (4, start.y)).error) {
              this.fields [end.x, end.y] = tmpPosition;
              return true;
            } else {
              tmpPosition.hasMoved = false;
              this.fields [start.x, start.y] = tmpPosition;
            }
          } else {
            this.fields [start.x, start.y] = this.fields [start.x + 1, start.y];
            this.fields [start.x, start.y].hasMoved = false;
            this.fields [start.x + 1, start.y] = new Empty ();
          }

        }
      }
      return false;
    }

    public string getFieldFigure (coord c)
    {
      return this.fields [c.x, c.y].GetType ().Name;
    }

    public string getFieldFigure (int x, int y)
    {
      return this.fields [x, y].GetType ().Name;
    }

  }
}

