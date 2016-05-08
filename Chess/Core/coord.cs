using System;

namespace Chess
{
  // Definition of the struct used for coordinates
  public struct coord
  {
    public int x;
    public int y;

   // Constructor of the class coord
    public coord (int x, int y) {
      this.x = x;
      this.y = y;
    }
  }
}