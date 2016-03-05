using System;

namespace Chess
{
  public class Figure
  {
    private string color;
    public bool hasMoved { get; set; }
    public coord rule { get; set; }

    public Figure (string color) {
      this.color = color;
      this.hasMoved = false;
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
    /* Method for the movement of the figure on the board */
    public virtual bool move(Board board, coord start, coord end) {
      return true;
    }
    /* Method for checking the movement.If the movement is not possible */
    public virtual bool checkMove(Board board, coord start, coord end) {
      return true;
    }
  }
}

