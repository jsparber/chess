using System;

namespace Chess
{
  public class Message
  {
    public bool error { get; set;}
    public string msg { get; set;}
    public string player { get; set;}

    public Message (bool error, string msg)
    {
      this.error = error;
      this.msg = msg;
      this.player = "";
    }

    public Message (bool error, string msg, string player)
    {
      this.error = error;
      this.msg = msg;
      this.player = player;
    }

    public void print ()
    {
      Console.WriteLine ("Error: " + this.error.ToString().ToLower() + ", Message: " + this.msg);
    }

    public string format () {
      string returnMsg = "It's " + this.player + "'s turn.";

      switch (this.msg) {
      case "check":
        returnMsg += " | " + this.player + " is in check";
        break;
      case "checkmate":
        string opColor = (player == "white") ? "black" : "white";
        returnMsg = this.player + " is checkmate | " + opColor + " wins";
        break;
      }
      return returnMsg;
    }
  }
}

