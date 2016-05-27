using System;

namespace Chess
{
  public class Message
  {
    public bool error { get; set;}      // If it is true an error has occurred
    public string msg { get; set;}      // String for the message
    public Player player { get; set;}   // Player object
    public string action { get; set;}   // Action to do

    // Constructor
    public Message (bool error, string msg, string action, Player player)
    {
      this.error = error;
      this.msg = msg;
      this.player = player;
      this.action = action;
    }

    // Virtual method that print true  on the terminal if there is an error and eventually print a message
    public virtual void print ()
    {
      Console.WriteLine ("Error: " + this.error.ToString().ToLower() + ", Message: " + this.msg);
    }

    // method for printing message to user
    public virtual string format () {
      string returnMsg = "It's " + this.player.next().ToString() + "'s turn.";

      switch (this.msg) {
      case "check":
        returnMsg += " | " + this.player.next().ToString() + " is in check";
        break;
      case "checkmate":
        returnMsg = this.player.next().ToString() + " is checkmate | " + this.player.ToString() + " wins";
        break;
      }
      return returnMsg;
    }
  }
}

