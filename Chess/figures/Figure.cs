using System;

namespace Chess
{
  public class Figure
  {
    public string color { get; set; }   /* String for the color of figures */

    public bool hasMoved { get; set; }  /* Flag for checking if the figure has moved */

    public coord rule { get; set; }

    public Figure (string color)
    {
      this.color = color;
      this.hasMoved = false;
    }

    public Figure ()
    {
      this.color = "";
      this.hasMoved = false;
    }

    /* Method for the movement of the figure on the board */
    public virtual bool move (Board board, coord start, coord end)
    {
      return true;
    }
  }
}

