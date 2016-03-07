using System;

namespace Chess
{
  public class Message
  {
    public bool error { get; set;}
    public string msg { get; set;}
    public string player { get; set;}
    public string action { get; set;}

    public Message (bool error, string msg, string action, string player)
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
      string opPlayer = (this.player == "white") ? "black" : "white";
      string returnMsg = "It's " + opPlayer + "'s turn.";

      switch (this.msg) {
      case "check":
        returnMsg += " | " + opPlayer + " is in check";
        break;
      case "checkmate":
        returnMsg = opPlayer + " is checkmate | " + this.player + " wins";
        break;
      }
      return returnMsg;
    }
  }
}

