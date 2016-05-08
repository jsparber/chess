using System;

namespace Chess
{
  /* Class for the bishop figure */
  class Bishop : Figure
  {
    /* Constructor of the figure bishop */
    public Bishop (string color) : base (color)
    {
    }
    /* Method for the movement of the bishop*/
    public override bool move (Board board, coord start, coord end)
    {
      if (Math.Abs (start.x - end.x) == Math.Abs (start.y - end.y)) {
          coord tmp = start;
          while (!tmp.Equals (end)) {
          if (board.getFieldFigureName (tmp) != "Empty" && !tmp.Equals(start))  // If there is an object along trajectory
              return false;                                                     // movement isn't permitted
            if (tmp.x > end.x && tmp.y > end.y) {                               // If temp.x and temp.y are major than their end
              tmp.x--;
              tmp.y--;
            }
            if (tmp.x > end.x && tmp.y < end.y) {                               // or temp.x is major and temp.x is minor
              tmp.x--;
              tmp.y++;
            }
            if (tmp.x < end.x && tmp.y > end.y) {                               // or temp.x is minor and temp.y is major
              tmp.x++;
              tmp.y--;
            }
            if (tmp.x < end.x && tmp.y < end.y) {                               // or temp.x is minor and temp.y is minor
              tmp.x++;
              tmp.y++;
            }
          }
          return true;                                                          // movement is allowed
      }
      return false;
    }
  }
}