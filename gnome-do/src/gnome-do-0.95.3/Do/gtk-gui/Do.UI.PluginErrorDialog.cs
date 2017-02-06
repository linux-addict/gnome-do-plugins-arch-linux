
// This file has been generated by the GUI designer. Do not modify.
namespace Do.UI
{
	public partial class PluginErrorDialog
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Table table1;
		private global::Gtk.Label file_lbl;
		private global::Gtk.Label header_lbl;
		private global::Gtk.Image image33;
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Do.UI.PluginErrorDialog
			this.Name = "Do.UI.PluginErrorDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Do.UI.PluginErrorDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(5));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.file_lbl = new global::Gtk.Label ();
			this.file_lbl.Name = "file_lbl";
			this.file_lbl.Xalign = 0F;
			this.file_lbl.Wrap = true;
			this.file_lbl.Selectable = true;
			this.table1.Add (this.file_lbl);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.file_lbl]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			// Container child table1.Gtk.Table+TableChild
			this.header_lbl = new global::Gtk.Label ();
			this.header_lbl.Name = "header_lbl";
			this.header_lbl.Xalign = 0F;
			this.header_lbl.UseMarkup = true;
			this.table1.Add (this.header_lbl);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.header_lbl]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(1));
			// Container child table1.Gtk.Table+TableChild
			this.image33 = new global::Gtk.Image ();
			this.image33.Name = "image33";
			this.image33.Xalign = 1F;
			this.image33.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-dialog-error", global::Gtk.IconSize.Dialog);
			this.table1.Add (this.image33);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.image33]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(1));
			this.hbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.table1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			w7.Padding = ((uint)(6));
			// Internal child Do.UI.PluginErrorDialog.ActionArea
			global::Gtk.HButtonBox w8 = this.ActionArea;
			w8.Name = "dialog1_ActionArea";
			w8.Spacing = 10;
			w8.BorderWidth = ((uint)(5));
			w8.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8 [this.buttonOk]));
			w9.Expand = false;
			w9.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 462;
			this.DefaultHeight = 163;
			this.Show ();
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
