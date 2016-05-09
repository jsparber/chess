using System;

namespace Chess
{
  /* Class for the knight figure */
  public class Knight : Figure
  {

    /* Constructor of the object knight */
    public Knight (string color) : base (color)
    {
    }

    /* Method for the movement of knight */
    public override bool move (Board board, coord start, coord end)
    {
      coord rule = new coord (1, 2);
      int x = rule.x;                     // x is setted to 1
      int y = rule.y;                     // y is setted to 2

      for (int i = 0; i < 2; i++) {
        if (i == 1) {                     // When i is equal to 1
          x = rule.y;                     // x is setted to 2
          y = rule.x;                     // and y is setted to 1
        }
        if (start.x + x == end.x) {       // If the movement on x is equal to starting position plus x
          if (start.y + y == end.y) {     // and the movement on y is equal to starting position plus y 
            return true;                  // movement is permitted
          }
        }
        if (start.x - x == end.x) {       // If the movement on x is equal to starting position minus x
          if (start.y - y == end.y) {     // and the movement on y is equal to starting position minus y 
            return true;                  // movement is permitted
          }
        }
        if (start.x - x == end.x) {       // If the movement on x is equal to starting position minus x
          if (start.y + y == end.y) {     // and the movement on y is equal to starting position plus y 
            return true;                  // movement is permitted
          }
        }
        if (start.x + x == end.x) {       // If the movement on x is equal to starting position plus x
          if (start.y - y == end.y) {     // and the movement on y is equal to starting position minus y 
            return true;                  // movement is permitted
          }
        }
      }
      return false;                       // Other movement aren't permitted
    }
  }
}