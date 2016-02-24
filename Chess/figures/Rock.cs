using System;

namespace Chess
{
  public class Rock : Figure
	{
    public Rock (string color) : base (color)
    {
      this.rule = new coord (1, 0);
    }
    public override bool move (Figure[,] board, coord start, coord end)
    {
      for (int x = start.x; x <= end.x; x++) {
     //   singleMove(board, new coord(start.x +x, start,y), new coord(
     // }
     // for (int y = start.y; x <= end.y; y++) {
       // ``:while }
      return false;
    }

    private bool singleMove (Figure[,] board, coord start, coord end) {
      int x = this.rule.x;
      int y = this.rule.y;

      for (int i = 0; i < 2; i++) {
        if (i == 1) {
          x = this.rule.y;
          y = this.rule.x;
        }
        if (start.x + x == end.x) {
          if (start.y + y == end.y) {
            return true;
          }
        }
        if (start.x - x == end.x) {
          if (start.y - y == end.y) {
            return true;
          }
        }
        if (start.x - x == end.x) {
          if (start.y + y == end.y) {
            return true;
          }
        }
        if (start.x + x == end.x) {
          if (start.y - y  == end.y) {
            return true;
          }
        }
      }
      return false;
    }
	}

}

