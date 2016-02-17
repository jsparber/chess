using System;

namespace Chess
{
  public class Figure
  {
    private string color;

    protected string Color {
      get {return color;}
      set {color = value;}
    }

    public string getColor {
      get {return color;}
    }

    public virtual bool move(Figure[,] board, coord start, coord end) {
      return true;
    }
  }
}

