using System;

namespace Chess
{
  public class Pawn : Figure
	{
    public Pawn (string color) : base(color)
    {
    }
    public override bool move(Board board, coord start, coord end) {
      /* Basic movement of pawn: one tile ahead */

      /* This method check the color of the figure, if it is white*/
      /* the final position is equal to the initial position with an increment */
      /* of one of the value y,else the final position is equal to the initial position */
      /* with a decrement of one of the value y */

      if (this.Color == "white") {    /* Check of the color of the figure */

        /* If the final value of y is equal to the starting value plus one */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y + 1 == end.y) {   
          if (start.x == end.x) {
            return true;
          }
        }

        /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
        return false;
      } 
      /* If the color is black we have a decrement of the value y */
      else {

        /* If the final value of y is equal to the starting value minus one */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y - 1 == end.y) {
          if (start.x == end.x) {
            return true;
          }
        }

        /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
        return false;
      }
    }
	}
}

