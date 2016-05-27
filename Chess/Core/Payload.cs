using System;

namespace Chess
{
  // Class for transport of information
  public class Payload
  {
    public bool error { get; }      // If it is true there is an error
    public string action { get; }   // Action to do
    public coord startPos { get; }  // Coord of starting position
    public coord endPos { get; }    // Coord of ending position
    public Figure figure { get; }   // Istance of a figure

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

