using System;

namespace Chess
{

  /* Class for the queen figure */
  public class Queen : Figure
  {

    /* Constructor of the object queen */
    public Queen (string color) : base (color)
    {
    }

    /* Method for the movement of the queen */
    public override bool move (Board board, coord start, coord end)
    {
      // Diagonal movement
      if (Math.Abs (start.x - end.x) == Math.Abs (start.y - end.y)) {
        coord tmp = start;
        while (!tmp.Equals (end)) {                                              // Until tmp isn't equal to end coordinates:
          if (board.getFieldFigureName (tmp) != "Empty" && !tmp.Equals(start))   // If there is an object along trajectory
            return false;                                                        // movement isn't permitted
          if (tmp.x > end.x && tmp.y > end.y) {                                  // If temp.x and temp.y are major than their end
            tmp.x--;                                                             //Decrement both
            tmp.y--;
          }
          if (tmp.x > end.x && tmp.y < end.y) {                                 // or temp.x is major and temp.x is minor
            tmp.x--;                                                            // decrement x
            tmp.y++;                                                            // increment y
          }
          if (tmp.x < end.x && tmp.y > end.y) {                                 // or temp.x is minor and temp.y is major
            tmp.x++;                                                             // increment x
            tmp.y--;                                                             // decrement y
          }
          if (tmp.x < end.x && tmp.y < end.y) {                                  // or temp.x is minor and temp.y is minor
            tmp.x++;                                                             // Increment both
            tmp.y++;
          }
        }
        return true;                                                             // movement is allowed if there isn't an object along trajectory
      }
     
      // Vertical and horizontal movement
      if (start.x == end.x) {                                                    // Check for the vertical movement
        if (start.y < end.y) {                                                   // If the end position is major than the starting position
          for (int i = start.y + 1; i < end.y; i++) {                           // Check for an object in this trajectory             
            if (board.getFieldFigureName (start.x, i) != "Empty") {     
              return false;                                                     // If there is one (not empty) movement isn't allowed
            }
          }
        } else {                                                               // If the end position is minor than the starting position
          for (int i = start.y - 1; i > end.y; i--) {                           // Check for an object in this trajectory 
            if (board.getFieldFigureName (start.x, i) != "Empty") {
              return false;                                                    // If there is one (not empty) movement isn't allowed
            }
          }
        }
        return true;                                                            // If there aren't object movement is permitted

      } else if (start.y == end.y) {                                            // Check for the horizontal movement
        if (start.x < end.x) {                                                  // If the end position is major than the starting position
          for (int i = start.x + 1; i < end.x; i++) {                           // Check for an object in this trajectory       
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;                                                     // If there is one (not empty) movement isn't allowed
            }
          }
        } else {                                                               // If the end position is minor than the starting position
          for (int i = start.x - 1; i > end.x; i--) {                          // Check for an object in this trajectory 
            if (board.getFieldFigureName (i, start.y) != "Empty") {
              return false;                                                    // If there is one (not empty) movement isn't allowed
            }
          }
        }
        return true;                                                           // If there aren't object along trajectory movement is permitted
      }  
      return false;                                                            // Any other case different from movements horizontal,diagonal or vertical aren't permitted
    }
  }
}