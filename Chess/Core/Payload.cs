using System;

namespace Chess
{
  public class Payload
  {
    public bool error { get; }
    public string action { get; }
    public coord startPos { get; }
    public coord endPos { get; }
    public Figure figure { get; }

    //payload for chooser response
    public Payload (bool error, string action, Figure f, coord pos)
    {
      this.startPos = pos;
      this.action = action;
      this.error = error;
      this.figure = f;
    }
    //payload for move command
    public Payload (bool error, string action, coord start, coord end)
    {
      this.startPos = start;
      this.endPos = end;
      this.action = action;
      this.error = error;
    }

    //payload for check selection
    public Payload (bool error, string action, coord start)
    {
      this.startPos = start;
      this.action = action;
      this.error = error;
    }
  }
}

