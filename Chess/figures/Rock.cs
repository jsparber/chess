using System;

namespace Chess
{
  // Class for the rock figure
  public class Rock : Figure
  {

    // Constructor of the rock figure
    public Rock (string color) : base (color)
    {
    }
     
    // Method for the movement of rock
    public override bool move (Board board, coord start, coord end)
    {
      //  int x = this.rule.x;
      // int y = this.rule.y;

      if (start.x == end.x) {
        if (start.y < end.y) {
          for (int i = start.y + 1; i < end.y; i++) {  
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.y - 1; i > end.y; i--) {  
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;
            }
          }
        }
        return true;
      } else if (start.y == end.y) {
        if (start.x < end.x) {
          for (int i = start.x + 1; i < end.x; i++) {  
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;
            }
          }
        } else {
          for (int i = start.x - 1; i > end.x; i--) {  
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;
            }
          }
        }
        return true;
      }  
      return false;
    }      
  }
}