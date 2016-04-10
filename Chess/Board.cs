using System;
using System.Collections.Generic;

namespace Chess
{
  public class Board
  {
    //starting layout for the game
    //lower case is black
    //X or any char differnt than rnbqkp is considered empty
    /*const string layout = "RNBKQBNR\n" +
                          "PPPPPPPP\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "pppppppp\n" +
                          "rnbkqbnr";
*/
        const string layout = "RNBKQBNR\n" +
                          "PPPPPPPP\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "XXXXXXXX\n" +
                          "ppppQppp\n" +
                          "rnbkqbnr";

    //chooseable figures for the pawn
    const string chooseLayout = "RNBQ";

    private Figure[,] fields;
    public List<Figure> removedFigures { get; }
    public Figure[] chooseableFigures { get; }

    public coord size { get; }

    public Board ()
    {
      removedFigures = new List<Figure> ();
      int lineNumber = 1;  // is 1 because the last line dosen't have a \n
      int lineLength = 0;
      for (int i = 0; i < layout.Length; i++) {
        if (layout [i] == '\n') {
          lineNumber++;
        } else
          lineLength++;
      }
      lineLength /= lineNumber;

      //create array with the right size
      this.fields = new Figure[lineLength, lineNumber];
      //save size
      this.size = new coord (lineLength, lineNumber);

      //fill up the array with the right figures
      int c = 0;
      for (int y = 0; y < lineNumber; y++) {
        for (int x = 0; x < lineLength; x++) {
          if (layout [c] == '\n')
            c++;
          this.fields [x, y] = figureLookup (layout [c]);
          c++;
        }
      }
      this.chooseableFigures = createChooseableFigures ();
    }

    //create array of the chooseable figures without any color
    public Figure[] createChooseableFigures () {
      Figure[] chooseableFigures = new Figure[chooseLayout.Length];
      for  (int i = 0; i < chooseLayout.Length; i++) {
        chooseableFigures[i] = figureLookup (chooseLayout [i]);
        chooseableFigures [i].color = "";
        }
      return chooseableFigures;
    }

    public Message switchFigures (Figure figure, coord position)
    {
      Player player = new Player (getFieldFigureColor (position));
      Message result = new Message (false, "", "", player);
      this.fields [position.x, position.y] = figure;
      if (isCheck (player.next())) {
        result.msg = "check";
        if (isCheckMate (player.next(), new coord (0, 0))) {
          result.msg = "checkmate";
        }
      }
      return result;
      
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

    public Message Move (Player player, coord start) {
          return new Message (this.getFieldFigureName (start) == "Empty" || this.getFieldFigureColor (start) != player.ToString(), "firstClick", "", player);
    }

    public Message Move (Player player, coord start, coord end)
    {
        Message result = new Message (false, "", "", player);
      if (doCastling (player, start, end)) {
        return result;
      } else if (doEnPassant (player, start, end)) { 
        return result;
      } else if (checkMove (player, start, end) && !isCheck (player, start, end)) {
        if (this.fields [end.x, end.y].GetType ().Name != "Empty") {
          this.removedFigures.Add (this.fields [end.x, end.y]);
        }
        this.fields [end.x, end.y] = this.fields [start.x, start.y];
        this.fields [start.x, start.y] = new Empty ();

        //check if with this move the other player will be in check or even checkmate
        if (isCheck (player.next())) {
          result.msg = "check";
          if (isCheckMate (player.next(), new coord (0, 0))) {
            result.msg = "checkmate";
          }
        }
        if (this.getFieldFigureName (end) == "Pawn") {
          ((Pawn)this.fields [end.x, end.y]).justMoved = true;
        }

        //remove all justMoved
        for (int x = 0; x < this.size.x; x++) {
          for (int y = 0; y < this.size.y; y++) {
            if (this.fields [x, y].color == player.ToString() && getFieldFigureName (new coord (x, y)) == "Pawn") {
              ((Pawn)this.fields [x, y]).justMoved = false;
            }
          }
        }

        //set moved Pawn's justMoved to true;
        if (this.getFieldFigureName (end) == "Pawn" && (start.y + 2 == end.y || start.y - 2 == end.y)) {
          ((Pawn)this.fields [end.x, end.y]).justMoved = true;
        }
        if (this.getFieldFigureName (end) == "Pawn" && (end.y == 0 || end.y == 7)) {
          result.action = "chooser";
        }
        this.fields [end.x, end.y].hasMoved = true;
        return result;
      } 
      result.error = true;
      return result;
    }

    //returns true if the move is possible
    //retruns false if the move is not possible
    private bool checkMove (Player player, coord start, coord end)
    {
      if ((this.fields [start.x, start.y].GetType ().Name == "Empty") ||
        (this.fields [start.x, start.y].color != player.ToString()) ||
        (this.fields [end.x, end.y].color == player.ToString()))
        return false; 

      return this.fields [start.x, start.y].move (this, start, end);
    }

    //check if the king will be in check after this move and don't allow it if it is
    private bool isCheck (Player player, coord start, coord end)
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
          if (this.fields [x, y].color == player.ToString() && getFieldFigureName (new coord (x, y)) == "King") {
            king = new coord (x, y);
            noKing = false;
          }
        }
      }
      if (!noKing) {
        for (int x = 0; x < this.size.x && !res; x++) {
          for (int y = 0; y < this.size.y && !res; y++) {
            //if a move is posiblie means the king is checked
            if (checkMove (player.next(), new coord (x, y), king))
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

    private bool isCheck (Player player)
    {
      return isCheck (player, new coord (), new coord ()); 
    }

    private bool isCheckMate (Player player, coord start)
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
    //bug removes figure also when the casling is not legid
    private bool doCastling (Player player, coord start, coord end)
    {
      if (this.getFieldFigureName (start) == "King" && this.fields [start.x, start.y].color == player.ToString() && this.fields [start.x, start.y].hasMoved == false) {
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

    private bool doEnPassant (Player player, coord start, coord end)
    {
      int direction;
      if (player.ToString() == "white") {
        direction = 1;
      } else {
        direction = -1;
      }
      if (this.getFieldFigureName (start) == "Pawn" &&
        this.fields [start.x, start.y].color == player.ToString() &&
          (start.x + 1 == end.x || start.x - 1 == end.x) &&
          start.y + direction == end.y &&
          this.getFieldFigureName(end.x, start.y) == "Pawn" &&
          ((Pawn)this.fields [end.x, start.y]).justMoved &&
          (this.getFieldFigureName (end.x, end.y) == "Empty")) {
        //do move;
        this.removedFigures.Add (this.fields [end.x, end.y - direction]);
        this.fields [end.x, end.y - direction] = new Empty ();
        this.fields [end.x, end.y] = this.fields [start.x, start.y];
        this.fields [start.x, start.y] = new Empty ();
        return true;
      }

      return false;
    }

    public string getFieldFigureName (coord c)
    {
      return getField (c).name ();
    }

    public string getFieldFigureName (int x, int y)
    {
      return getFieldFigureName (new coord (x, y));
    }

    public string getFieldFigureColor(coord c) {
      return getField(c).color;
    }

    public Figure getField(coord c) {
      return this.fields [c.x, c.y];
    }
  }
}