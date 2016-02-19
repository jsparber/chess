using System;
using Gtk;

namespace Chess
{
  [System.ComponentModel.ToolboxItem (true)]
  public partial class FieldWidget : Gtk.EventBox
  {
    public coord position { get; set; }
    public string color { get; set; }
    public string colorBg { get; set; }
    public string figure { get; set; }
    public FieldWidget (string colorBg, string figure, string color)
    {
      Gdk.Color col = new Gdk.Color();
      Gdk.Color.Parse(colorBg, ref col);
      if (figure != "") {
        string imgName = color.ToLower () [0].ToString () + figure.ToUpper () [0].ToString ();
        Image img = loadSvg(imgName, new coord(100, 100));
        this.Add(img);
      }
      this.ModifyBg(StateType.Normal, col);
      this.figure = figure;
      this.color = color;
      this.colorBg = colorBg;
      //this.Build ();
    }

    public Gtk.Image loadSvg (string file, coord size)
    {
      Gdk.Pixbuf display = new Gdk.Pixbuf ("/home/julian/Projects/Chess/Chess/Chess/img/cburnett/" + file + ".svg", size.x, size.y);
      return (new Gtk.Image (display));
    }
  }
}

