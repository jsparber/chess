using System;

namespace Chess
{
  public class King : Figure
  {
    public King (string color) : base (color)
    {
    }

    public override bool move (Board board, coord start, coord end)
    {
      for (int x = (start.x == 0) ? 0 : start.x - 1; x <= start.x + 1; x++) {
        for (int y = (start.y == 0) ? 0 : start.y - 1; y <= start.y + 1; y++) {
          if (end.Equals (new coord (x, y)))
            return true;
        }
      }
      return false;
    }
  }
}

