using System;

namespace Chess
{
  /* Class for the king figure*/
  public class King : Figure                         
  {

    /* Constructor of the figure king */
    public King (string color) : base (color)
    {
    }

    /* Method for the movement of king */
    public override bool move (Board board, coord start, coord end)
    {
      for (int x = (start.x == 0) ? 0 : start.x - 1; x <= start.x + 1; x++) {   /* If the movement on x is between -1 and 1(included) */
        for (int y = (start.y == 0) ? 0 : start.y - 1; y <= start.y + 1; y++) { /* if the movement on y is between -1 and 1(included) */
          if (end.Equals (new coord (x, y)))                                    /* and the end coordinates are updated */  
            return true;                                                        /* this method return a true value */
        }
      }
      return false;                                                             /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */                                                 
    }
  }
}