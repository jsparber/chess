using System;

namespace Chess
{
  class Bishop : Figure
	{
    public Bishop (string color)
    {
      this.Color = color;
    }
    public override bool move(Figure[,] board, coord start, coord end) {
      return true;
    }
  }

}

