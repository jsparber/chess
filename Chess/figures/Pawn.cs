using System;

namespace Chess
{
  public class Pawn : Figure
	{
    private int count;
    /* Constructor of the object pawn*/
    public Pawn (string color) : base(color)
    {
      this.count = 0;     /* Count for checking if the pawn has moved */      
    }


    public override bool move(Board board, coord start, coord end) {
      //TODO counter for movement; movement of 2 tiles
      /* Counter TODO TODO TODO  IL PEDONE NON PUÒ ASSOLUTAMENTE SALTERE LE ALTRE PEDINE */
     /* int count = 0;              
      int doublemov = 0;          /* Count for checking if the pawn has done the doublemove */ 

 
       

       
        
        /* If the color is black we have a decrement of the value y */
     //   else {

         

          /* Setting count to two */
       //   this.count = 2;

          /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
       //   return false;/***********************************/

    //  }
        /*Setting doublemov to one 
        doublemov = 1;*/

      
    //  }
      /*-----------------------------------------------------------------*/
        
      /* Basic movement of pawn: one tile ahead */

      /* This method check the color of the figure, if it is white*/
      /* the final position is equal to the initial position with an increment */
      /* of one of the value y,else the final position is equal to the initial position */
      /* with a decrement of one of the value y */

      if (this.Color == "white") {    /* Check of the color of the figure */

       /*???????????????????????????????????????????????????????????*/
      if(this.count == 0){
          /* Special movement of pawn: two tile ahead */

          /* the final position is equal to the initial position with an increment */
          /* of two of the value y,else the final position is equal to the initial position */
          /* with a decrement of two of the value y */

        /* If the final value of y is equal to the starting value plus two */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y + 2 == end.y) {  
          if (start.x == end.x) {
            /* Setting count to two */
            this.count = 2;

            return true;
          }
        }
      }

        /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

        /* If the final value of y is equal to the starting value plus one */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y + 1 == end.y) {   
          if (start.x == end.x) {
            /* If count is zero it will be set to one */        
            if(this.count == 0){             
              this.count = 1;
            }
            return true;

          }
        }

        /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
        return false;
      } 
      /* If the color is black we have a decrement of the value y */
      else {

      /*????????????????????????????????????????????????????????????????????*/

      if(this.count == 0){

        /* If the final value of y is equal to the starting value minus two */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y - 2 == end.y) {
          if (start.x == end.x) {
            /* Setting count to two */
            this.count = 2;

            return true;
          }
        }
      }


      /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!e*/

        /* If the final value of y is equal to the starting value minus one */
        /* there is a control for the value x:if the final value is equal */
        /* to the starting value the movement is possible */
        if (start.y - 1 == end.y) {
          if (start.x == end.x) {
            /* If count is zero it will be set to one */        
            if (this.count == 0) {             
              this.count = 1;
            }
            return true;

          }
        }
          /* If count is zero it will be set to one */        
        if (this.count == 0) {             
          this.count = 1;
        }

        /* If the value of x and y are not corresponding to the rule the movement isn't allowed  */
        return false;
      }         
    }
	}
}