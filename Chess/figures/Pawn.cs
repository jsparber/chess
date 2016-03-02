using System;

namespace Chess
{
  public class Pawn : Figure
	{
    /* Definition of the variable count used for the check of the movement of the pawn */
    /* legends: count = 0 pawn not moved;count = 1 pawn moved the first time of one tile; */
    /* count = 2 pawn has moved the first time of two tiles(it can be )*/

    private int count;

    /* Constructor of the object pawn*/
    public Pawn (string color) : base(color)
    {
      this.count = 0;     /* Count for checking if the pawn has moved */      
    }


    public override bool move(Board board, coord start, coord end) {
      //TODO mangiare in diagonale e impedire di mangiare dritti

      /* If the color is white we have an increment of y;if the color is black we have a decrement of y. */
      /* this method return the value "true" if the movement is permitted */

      if (this.Color == "white") {      /* Check of the color of the figure,case of a white figure */       
      if(this.count == 0) {             /* If count is zero the figure has never moved and can move of two tiles ahead */         
        if (start.y + 2 == end.y) {     /* If final position is equal to initial position with a vertical increment of two */
          if (start.x == end.x) {       /* and there is the same x position the movement is allowed */       
              this.count = 2;           /* Setting count to two */
            return true;
          }
        }
      }      
        if (start.y + 1 == end.y) {     /* Basic movement:1 tile ahead */ 
          if (start.x == end.x) {                
            if(this.count == 0) {       /* If count is zero it will be set to one */           
              this.count = 1;
            }
            return true;
          }
        }       
        return false;                   /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
      } 
      else {                            /* case of a black figure */      
        if(this.count == 0) {           /* If count is zero the figure has never moved and can move of two tiles ahead */     
          if (start.y - 2 == end.y) {   /* If final position is equal to initial position with a vertical decrement of two */
            if (start.x == end.x) {     /* and there is the same x position the movement is allowed */     
              this.count = 2;           /* Setting count to two */
            return true;
          }
        }
      }      
        if (start.y - 1 == end.y) {     /* Basic movement:1 tile ahead */
          if (start.x == end.x) {             
            if (this.count == 0) {      /* If count is zero it will be set to one */               
              this.count = 1;
            }
            return true;
          }
        }
        return false;                   /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
      }         
    }
	}
}