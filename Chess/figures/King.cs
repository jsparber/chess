using System;

namespace Chess
{
  public class King : Figure
  {
    public King (string color) : base (color)
    {
      this.rule = new coord (0, 0);
    }


    public override bool move(Board board, coord start, coord end) {
     
        //allow to move on upper dx and downer dx
          if (start.x + 1 == end.x){     
        if(start.y + 1 == end.y){ 
            return true;
        }
        }

        if (start.x + 1 == end.x){

            if(start.y - 1 == end.y){
        return true;
          }
      }
          if (start.y + 1 == end.y){
        return true;
          }

        //allow to move on upper sx and downer sx
       /* if (start.x - 1 == end.x){
          if((start.y +1 == end.y)||(start.y - 1 == end.y))
          }
        return true;

        if (start.y - 1 == end.y)
          return true;

        //return false;*/

        //problem:king is moving like knight and
        //is possible to move in side horizontal && vertical
        //(from the end position of knightlike move
   
        return true;

      }
    }
  }
