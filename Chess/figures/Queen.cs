using System;

namespace Chess
{
  public class Queen : Figure
  {
    public Queen (string color) : base (color)
    {
    }


    public override bool move (Board board, coord start, coord end)
    {
      //bishop case
      if (Math.Abs (start.x - end.x) == Math.Abs (start.y - end.y)) {
        coord tmp = start;
        while (!tmp.Equals (end)) {
          if (board.getFieldFigure (tmp) != "Empty" && !tmp.Equals (start))
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

      //if not bishop case its rock case
      if (start.x == end.x) {
        if (start.y < end.y) {
          for (int i = start.y + 1; i < end.y; i++) {  
            if (board.getFieldFigure (start.x, i) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.y - 1; i > end.y; i--) {  
            if (board.getFieldFigure (start.x, i) != "Empty") {
              return false;
            }
          }
        }
        return true;
      } else if (start.y == end.y) {
        if (start.x < end.x) {
          for (int i = start.x + 1; i < end.x; i++) {  
            if (board.getFieldFigure (i, start.y) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.x - 1; i > end.x; i--) {  
            if (board.getFieldFigure (i, start.y) != "Empty") {
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

