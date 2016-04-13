using System;
using System.Collections.Generic;

namespace Chess
{
  public class Game
  {
    private Board board;
    private Player player;

    public Game ()
    {
      this.board = new Board ();
      this.player = new Player ("white");
    }

    //interaction function for the user interface to the game
    public Message call (Payload data) {
      Message result = new Message (false, "", "", null);
      if (!data.error) {
        switch (data.action) {
        case "switchFigures": 
          result = this.board.switchFigures (data.figure, data.startPos);
          break;
        case "move":
          //need to block the game whenn waiting for click on the chooser
          result = this.board.Move (this.player, data.startPos, data.endPos);
          if (!result.error) {
            this.player = this.player.next ();
          }
          break;
        case "checkSelection":
          result = this.board.Move (this.player, data.startPos);
          break;
        }
      }
      return result; 
    }

    public Figure[] getChooseableFigures() {
      return this.board.chooseableFigures;
    }

    public coord getSize() {
      return this.board.size;
    }


    public List<Figure> getRemovedFigures ()
    {
      return this.board.removedFigures;
    }

    public string getFieldFigureName (coord coord)
    {
      return this.board.getFieldFigureName (coord);
    }

    public string getFieldFigureColor (coord coord)
    {
      return this.board.getFieldFigureColor (coord);
    }

    public Message initialState() {
      return new Message (false, "", "", player.next());
    }
  }
}