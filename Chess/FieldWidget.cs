using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Cairo;
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
      string imgName;
      if (figure != "") {
        if (figure.ToLower() != "knight") {
          imgName = color.ToLower () [0].ToString () + figure.ToUpper () [0].ToString ();
        } else {
          imgName = color.ToLower () [0].ToString () + "N";
        }
        Image img = loadSvg(imgName, new coord(100, 100));
        Image circle = loadCircle(new coord(100, 100));
        //should draw the circle with cario but I cann't add it do the Fixed elemend
        CairoGraphic g =  new CairoGraphic();
        g.ModifyBg(StateType.Normal, col);
        Fixed f = new Fixed ();
        //f.Add (circle);
        f.Add (img);
        f.ShowAll();
        this.Add(f);
        //this.Add(img);
        this.ShowAll ();
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
    public Gtk.Image loadCircle (coord size)
    {
      Gdk.Pixbuf display = new Gdk.Pixbuf ("/home/julian/Projects/Chess/Chess/Chess/img/circle.svg", size.x, size.y);
      return (new Gtk.Image (display));
    }
  }
}

