using System;

namespace Chess
{
  public class Pawn : Figure
  {
    /* Definition of the variable count used for the check of the movement of the pawn */

    /* Constructor of the object pawn*/
    public Pawn (string color) : base (color)
    {
    }


    /* returns true if the movement is permitted else false */
    public override bool move (Board board, coord start, coord end)
    {
      int direction;

      /* If the color is white we have an increment of y 
       * if the color is black we have a decrement of y. */

      if (this.Color == "white") {
        direction = 1;
      } else {
        direction = -1;
      }
      if (!this.hasMoved &&
          start.x == end.x &&
          start.y + (2 * direction) == end.y &&
          board.getFieldFigure (start.x, start.y + direction) == "Empty" &&
          board.getFieldFigure (start.x, start.y + (2 * direction)) == "Empty")
        return true;
      if (start.x == end.x &&
          start.y + direction == end.y &&
          board.getFieldFigure (start.x, start.y + direction) == "Empty")
        return true;
      if ((start.x + 1 == end.x || start.x - 1 == end.x) &&
          start.y + direction == end.y &&
          board.getFieldFigure (end) != "Empty") {
        return true;
      }

      return false;                   /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
    }
  }
}