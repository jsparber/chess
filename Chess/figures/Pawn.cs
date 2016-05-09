using System;

namespace Chess
{

  /* Class for the pawn figure */
  public class Pawn : Figure      
  {
    public bool justMoved { get; set; }

    /* Constructor of the object pawn*/
    public Pawn (string color) : base (color)
    {
      justMoved = false;     /* Definition of the boolean used for the checking if the pawn has moved */
    }

    /* Method for the movement of pawn */
    public override bool move (Board board, coord start, coord end)
    {
      int direction;        /* Int value for direction of movement */

      /* If the color is white we have an increment of y(positive direction) else a decrement */
      if (this.color == "white") {
        direction = 1;
      } else {
        direction = -1;
      }
      if (!this.hasMoved &&
          start.x == end.x &&
          start.y + (2 * direction) == end.y &&
          board.getFieldFigureName (start.x, start.y + direction) == "Empty" &&
          board.getFieldFigureName (start.x, start.y + (2 * direction)) == "Empty")
        return true;
      if (start.x == end.x &&
          start.y + direction == end.y &&
          board.getFieldFigureName (start.x, start.y + direction) == "Empty")
        return true;
      if ((start.x + 1 == end.x || start.x - 1 == end.x) &&
          start.y + direction == end.y &&
          board.getFieldFigureName (end) != "Empty") {
        return true;
      }

      return false;                   /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
    }
  }
}