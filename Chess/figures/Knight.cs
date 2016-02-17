using System;

namespace Chess
{
  public class Knight : Figure
	{
    public Knight (string color)
    {
      this.Color = color;
    }
    public override bool move(Figure[,] board, coord start, coord end) {
      return true;
    }
	}

}

