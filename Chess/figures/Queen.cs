using System;

namespace Chess
{

  /* Class for the queen figure */
  public class Queen : Figure
  {

    /* Constructor of the object queen */
    public Queen (string color) : base (color)
    {
    }

    /* Method for the movement of the queen */
    public override bool move (Board board, coord start, coord end)
    {
      // Diagonal movement
      if (Math.Abs (start.x - end.x) == Math.Abs (start.y - end.y)) {
        coord tmp = start;
        while (!tmp.Equals (end)) {
          if (board.getFieldFigureName (tmp) != "Empty" && !tmp.Equals (start))
            return false;
          if (tmp.x > end.x && tmp.y > end.y) {
            tmp.x--;
            tmp.y--;
          }
          if (tmp.x > end.x && tmp.y < end.y) {
            tmp.x--;
            tmp.y++;
          }
          if (tmp.x < end.x && tmp.y > end.y) {
            tmp.x++;
            tmp.y--;
          }
          if (tmp.x < end.x && tmp.y < end.y) {
            tmp.x++;
            tmp.y++;
          }
        }
        return true;
      }

      // Vertical and horizontal movement
      if (start.x == end.x) {
        if (start.y < end.y) {
          for (int i = start.y + 1; i < end.y; i++) {  
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.y - 1; i > end.y; i--) {  
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;
            }
          }
        }
        return true;
      } else if (start.y == end.y) {
        if (start.x < end.x) {
          for (int i = start.x + 1; i < end.x; i++) {  
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.x - 1; i > end.x; i--) {  
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;
            }
          }
        }
        return true;
      }  
      return false;
    }
  }
}