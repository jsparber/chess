using System;

namespace Chess
{
  public class Rock : Figure
	{
    public Rock (string color) : base (color)
    {
      this.rule = new coord (1, 0);
    }

    public override bool move (Figure[,] board, coord start, coord end)
    {
    //  int x = this.rule.x;
     // int y = this.rule.y;

      if (start.x == end.x) {
        if (start.y < end.y) {
          for (int i = start.y + 1; i < end.y; i++) {  
            if (board [start.x, i].GetType ().Name.ToLower () != "empty") {
              return false;
            }
          }
          return true;
        } else {
          for (int i = start.y - 1; i > end.y; i--) {  
            if (board [start.x, i].GetType ().Name.ToLower () != "empty") {
              return false;
            }
          }
          return true;
        }
      }
      else if (start.y == end.y) {
        if (start.x < end.x) {
          for (int i = start.x + 1; i < end.x; i++) {  
            if (board [i, start.y].GetType ().Name.ToLower () != "empty") {
              return false;
            }
          }
          return true;
        } else {
          for (int i = start.x - 1; i > end.x; i--) {  
            if (board [i, start.y].GetType ().Name.ToLower () != "empty") {
              return false;
            }
          }
          return true;
        }
      }  
         
      
        
      return false;
      }
  
      
    }

}