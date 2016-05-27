using System;
using System.Collections.Generic;

namespace Chess
{
  public class Game
  {
    private Board board;    // Istance of a board object
    private Player player;  // Istance of a player object

    // Constructor
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
          //need to block the game when waiting for click on the chooser
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

    // Get method that returns all chooseable figures
    public Figure[] getChooseableFigures() {
      return this.board.chooseableFigures;
    }

    // Get method that return size
    public coord getSize() {
      return this.board.size;
    }

    // List of removed figures
    public List<Figure> getRemovedFigures ()
    {
      return this.board.removedFigures;
    }

    // Method for getting the name of the figure
    public string getFieldFigureName (coord coord)
    {
      return this.board.getFieldFigureName (coord);
    }

    // Method for getting the color of the figure
    public string getFieldFigureColor (coord coord)
    {
      return this.board.getFieldFigureColor (coord);
    }

    // Message for the initial state
    public Message initialState() {
      return new Message (false, "", "", player.next());
    }
  }
}