using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Gtk;

namespace Chess
{
  public partial class TileWidget : Gtk.EventBox
  {
    public coord position { get; set; }   // Position 

    public string color { get; set; }     // Color of a tile

    public string figure { get; set; }    // Instance of a figure

    // constructor
    public TileWidget (string colorBg, string figure, string color, coord size)
    {
      string imgName;
      if (color != "" && figure != "" && figure.ToLower () != "empty") {
        if (figure.ToLower () != "knight") {
          imgName = color.ToLower () [0].ToString () + figure.ToUpper () [0].ToString ();
        } else {
          imgName = color.ToLower () [0].ToString () + "N";
        }
        Image img = loadSvg (imgName, size);
        Fixed f = new Fixed ();
        f.Add (img);
        f.ShowAll ();
        this.Add (f);
        this.Show ();
      }
      if (colorBg != "") {
        Gdk.Color col = new Gdk.Color ();
        Gdk.Color.Parse (colorBg, ref col);
        this.ModifyBg (StateType.Normal, col);
      }
      this.figure = figure;
      this.color = color;
    }

    // Method that load images of figures
    public Gtk.Image loadSvg (string file, coord size)
    {
      Gdk.Pixbuf display;
      string basePath = System.IO.Path.GetDirectoryName (System.Reflection.Assembly.GetExecutingAssembly ().GetName ().CodeBase).Substring (5);
      try {
        display = new Gdk.Pixbuf (basePath + @"/img/cburnett/" + file + ".svg", size.x, size.y);
      } catch (GLib.GException e) {
        Console.WriteLine (e);
        display = null;
      }
      return (new Gtk.Image (display));

    }

    // Method for loading of the circle that inscribe the figure when it is clicked
    public Gtk.Image loadCircle (coord size)
    {
      string basePath = System.IO.Path.GetDirectoryName (System.Reflection.Assembly.GetExecutingAssembly ().GetName ().CodeBase).Substring (5);
      Gdk.Pixbuf display = new Gdk.Pixbuf (basePath + @"/img/circle.svg", size.x, size.y);
      return (new Gtk.Image (display));
    }
  }
}