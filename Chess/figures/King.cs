﻿using System;

namespace Chess
{
  public class King : Figure
  {
    public King (string color) 
    {
      this.Color = color;
    }

    public override bool move(Figure[,] board, coord start, coord end) {
      return true;
    }
  }
}

