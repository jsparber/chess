using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Gtk;
namespace Chess
{
  [System.ComponentModel.ToolboxItem (false)]
  public partial class TileWidget : Gtk.EventBox
  {
    public coord position { get; set; }
    public string color { get; set; }
    public string colorBg { get; set; }
    public string figure { get; set; }
    public TileWidget (string colorBg, string figure, string color, coord size)
    {
      string imgName;
      if (color != "" && figure != "" && figure.ToLower() != "empty") {
        if (figure.ToLower() != "knight") {
          imgName = color.ToLower () [0].ToString () + figure.ToUpper () [0].ToString ();
        } else {
          imgName = color.ToLower () [0].ToString () + "N";
        }
        Image img = loadSvg(imgName, size);
        Fixed f = new Fixed ();
        f.Add (img);
        f.ShowAll();
        this.Add(f);
        this.Show ();
      }
      if (colorBg != "") {
        Gdk.Color col = new Gdk.Color ();
        Gdk.Color.Parse (colorBg, ref col);
        this.ModifyBg (StateType.Normal, col);
      }
        this.figure = figure;
        this.color = color;
        this.colorBg = colorBg;
    }

    public Gtk.Image loadSvg (string file, coord size)
    {
      Gdk.Pixbuf display;
      try {
        display = new Gdk.Pixbuf ("../../img/cburnett/" + file + ".svg", size.x, size.y);
      }
      catch (GLib.GException e) {
        Console.WriteLine (e);
        display = null;
      }
      return (new Gtk.Image (display));

    }
    public Gtk.Image loadCircle (coord size)
    {
      Gdk.Pixbuf display = new Gdk.Pixbuf ("../../img/circle.svg", size.x, size.y);
      return (new Gtk.Image (display));
    }
  }
}

