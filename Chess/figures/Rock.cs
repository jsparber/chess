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

      if (start.x == end.x) {                                          // Check for the vertical movement
        if (start.y < end.y) {                                         // If the end position is major than the starting position
          for (int i = start.y + 1; i < end.y; i++) {                  // Check for an object in this trajectory             
            if (board.getFieldFigureName (start.x, i) != "Empty") {     
              return false;                                            // If there is one (not empty) movement isn't allowed
            }
          }
        } else {                                                      // If the end position is minor than the starting position
          for (int i = start.y - 1; i > end.y; i--) {                 // Check for an object in this trajectory 
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;                                           // If there is one (not empty) movement isn't allowed
            }
          }
        }
        return true;                                                  // If there aren't object movement is permitted

      } else if (start.y == end.y) {                                  // Check for the horizontal movement
        if (start.x < end.x) {                                        // If the end position is major than the starting position
          for (int i = start.x + 1; i < end.x; i++) {                 // Check for an object in this trajectory       
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;                                            // If there is one (not empty) movement isn't allowed
            }
          }
        } else {                                                      // If the end position is minor than the starting position
          for (int i = start.x - 1; i > end.x; i--) {                 // Check for an object in this trajectory 
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;                                           // If there is one (not empty) movement isn't allowed
            }
          }
        }
        return true;                                                  // If there aren't object along trajectory movement is permitted
      }  
      return false;                                                   // If the movement isn't vertical or horizontal it isn't permitted
    }      
  }
}