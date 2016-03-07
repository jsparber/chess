using System;

namespace Chess
{
  public class Message
  {
    public bool error { get; set;}
    public string msg { get; set;}
    public Player player { get; set;}
    public string action { get; set;}

    public Message (bool error, string msg, string action, Player player)
    {
      this.error = error;
      this.msg = msg;
      this.player = player;
      this.action = action;
    }

    public void print ()
    {
      Console.WriteLine ("Error: " + this.error.ToString().ToLower() + ", Message: " + this.msg);
    }

    public string format () {
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

