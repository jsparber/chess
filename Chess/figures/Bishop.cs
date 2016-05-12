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
          while (!tmp.Equals (end)) {                                           // Until tmp isn't equal to end coordinates:
          if (board.getFieldFigureName (tmp) != "Empty" && !tmp.Equals(start))  // If there is an object along trajectory
              return false;                                                     // movement isn't permitted
            if (tmp.x > end.x && tmp.y > end.y) {                               // If temp.x and temp.y are major than their end
              tmp.x--;                                                          //Decrement both
              tmp.y--;
            }
            if (tmp.x > end.x && tmp.y < end.y) {                               // or temp.x is major and temp.x is minor
              tmp.x--;                                                          // decrement x
              tmp.y++;                                                          // increment y
            }
            if (tmp.x < end.x && tmp.y > end.y) {                               // or temp.x is minor and temp.y is major
              tmp.x++;                                                          // increment x
              tmp.y--;                                                          // decrement y
            }
            if (tmp.x < end.x && tmp.y < end.y) {                               // or temp.x is minor and temp.y is minor
              tmp.x++;                                                          // Increment both
              tmp.y++;
            }
          }
          return true;                                                          // movement is allowed if there isn't an object along trajectory
      }
      return false;                                                             // If the movement isn't diagonal it isn't permitted
    }
  }
}