using System;

namespace Chess
{
  public class Pawn : Figure
	{
    public Pawn (string color) : base(color)
    {
    }
    public override bool move(Figure[,] board, coord start, coord end) {

      return true;
    }
	}

}

