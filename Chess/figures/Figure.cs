using System;

namespace Chess
{
  public class Figure
  {
    private string color;
    public coord rule { get; set; }

    public Figure (string color) {
      this.color = color;
    }

   public Figure () {
    }
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

    public virtual bool checkMove(Figure[,] board, coord start, coord end) {
      return true;
    }
  }
}

