using System;
using System.Collections.Generic;

namespace Chess
{
  public class Game
  {
 
    public Board board { get; }

    private Player player;

    public Game ()
    {
      this.board = new Board ();
      this.player = new Player ("white");
    }

    public Message Move (coord start, coord end)
    {
      Message msg = this.board.Move (this.player, start, end);
      msg.player = this.player;
      if (!msg.error) {
        this.player = this.player.next ();
      }
      return msg;
    }

    public Message Move (coord start)
    {
      return new Message (this.board.getFieldFigureName (start) == "Empty" || this.board.getFieldFigureColor (start) != this.player.ToString(), "firstClick", "", this.player);
    }

    public List<Figure> getRemovedFigures ()
    {
      return this.board.removedFigures;
    }

    public Message initialState() {
      return new Message (false, "", "", player.next());
    }
  }
}