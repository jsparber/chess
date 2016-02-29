using System;

namespace Chess
{
  class Bishop : Figure
	{
    public Bishop (string color) : base(color)
    {
      this.rule = new coord (1, 1);
    }
    public override bool move(Board board, coord start, coord end) {
      if (start.Equals (end)) {
        //do the check
        return true;
      }
      //check if next field is empty
      else if ((new coord(start.x + this.rule.x, start.y + this.rule.y)).Equals(board.size) && board.getFieldFigure(new coord (start.x + this.rule.x, start.y + this.rule.y)) == "empty") {
        move (board, new coord (start.x + this.rule.x, start.y + this.rule.y), end);
      }
      return false;
    }




    public override bool checkMove(Board board, coord start, coord end) {
      int x = this.rule.x;
      int y = this.rule.y;

      for (int i = 0; i < 2; i++) {
        if (i == 1) {
          x = this.rule.y;
          y = this.rule.x;
        }
        if (start.x + x == end.x) {
          if (start.y + y == end.y) {
            return true;
          }
        }
        if (start.x - x == end.x) {
          if (start.y - y == end.y) {
            return true;
          }
        }
        if (start.x - x == end.x) {
          if (start.y + y == end.y) {
            return true;
          }
        }
        if (start.x + x == end.x) {
          if (start.y - y  == end.y) {
            return true;
          }
        }
      }
      return false;
    }
  }

}

