
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VScrollbar vscrollbar1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Chess");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vscrollbar1 = new global::Gtk.VScrollbar (null);
		this.vscrollbar1.Name = "vscrollbar1";
		this.vscrollbar1.Adjustment.Upper = 100;
		this.vscrollbar1.Adjustment.PageIncrement = 10;
		this.vscrollbar1.Adjustment.PageSize = 10;
		this.vscrollbar1.Adjustment.StepIncrement = 1;
		this.Add (this.vscrollbar1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
