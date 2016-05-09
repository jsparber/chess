using System;

namespace Chess
{
  /* Generic class for a figure */
  public class Figure
  {
    public string color { get; set; }   /* String for the color offigures */
    public bool hasMoved { get; set; }  /* Flag for checking if the figure has moved */

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

    public string name () {
      return this.GetType().Name;
    }
  }
}