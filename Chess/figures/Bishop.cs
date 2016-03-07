using System;

namespace Chess
{
  class Bishop : Figure
  {
    public Bishop (string color) : base (color)
    {
      this.rule = new coord (1, 1);
    }

    public override bool move (Board board, coord start, coord end)
    {
      if (Math.Abs (start.x - end.x) == Math.Abs (start.y - end.y)) {
          coord tmp = start;
          while (!tmp.Equals (end)) {
          if (board.getFieldFigureName (tmp) != "Empty" && !tmp.Equals(start))
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
      return false;
    }

  }

}

