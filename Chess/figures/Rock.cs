using System;

namespace Chess
{
  public class Rock : Figure
	{
    public Rock (string color) : base (color)
    {
      this.rule = new coord (1, 0);
    }
}
}

