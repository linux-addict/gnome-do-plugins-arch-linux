
// This file has been generated by the GUI designer. Do not modify.
namespace Do.UI
{
	public partial class PreferencesWindow
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Notebook notebook;
		private global::Gtk.HButtonBox hbuttonbox2;
		private global::Gtk.Button btn_help;
		private global::Gtk.Button btn_close;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Do.UI.PreferencesWindow
			this.WidthRequest = 428;
			this.HeightRequest = 440;
			this.Name = "Do.UI.PreferencesWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("GNOME Do Preferences");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-preferences", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.BorderWidth = ((uint)(6));
			// Container child Do.UI.PreferencesWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.notebook = new global::Gtk.Notebook ();
			this.notebook.CanFocus = true;
			this.notebook.Name = "notebook";
			this.notebook.CurrentPage = 0;
			this.hbox1.Add (this.notebook);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.notebook]));
			w1.Position = 0;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbuttonbox2 = new global::Gtk.HButtonBox ();
			this.hbuttonbox2.Name = "hbuttonbox2";
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btn_help = new global::Gtk.Button ();
			this.btn_help.CanFocus = true;
			this.btn_help.Name = "btn_help";
			this.btn_help.UseStock = true;
			this.btn_help.UseUnderline = true;
			this.btn_help.Label = "gtk-help";
			this.hbuttonbox2.Add (this.btn_help);
			global::Gtk.ButtonBox.ButtonBoxChild w3 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.btn_help]));
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.btn_close = new global::Gtk.Button ();
			this.btn_close.CanDefault = true;
			this.btn_close.CanFocus = true;
			this.btn_close.Name = "btn_close";
			this.btn_close.UseStock = true;
			this.btn_close.UseUnderline = true;
			this.btn_close.Label = "gtk-close";
			this.hbuttonbox2.Add (this.btn_close);
			global::Gtk.ButtonBox.ButtonBoxChild w4 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.btn_close]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbuttonbox2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbuttonbox2]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 450;
			this.DefaultHeight = 470;
			this.btn_close.HasDefault = true;
			this.Show ();
			this.btn_help.Clicked += new global::System.EventHandler (this.OnBtnHelpClicked);
			this.btn_close.Clicked += new global::System.EventHandler (this.OnBtnCloseClicked);
		}
	}
}
