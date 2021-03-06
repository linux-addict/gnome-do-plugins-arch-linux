// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gnome {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class Desktop {

		[DllImport("gnome-desktop-2")]
		static extern void gnome_desktop_prepend_terminal_to_vector(out int argc, IntPtr argv);

		public static int PrependTerminalToVector(string argv) {
			int argc;
			gnome_desktop_prepend_terminal_to_vector(out argc, GLib.Marshaller.StringToPtrGStrdup(argv));
			return argc;
		}

		[DllImport("gnome-desktop-2")]
		static extern bool gnome_desktop_thumbnail_has_uri(IntPtr pixbuf, IntPtr uri);

		public static bool ThumbnailHasUri(Gdk.Pixbuf pixbuf, string uri) {
			IntPtr native_uri = GLib.Marshaller.StringToPtrGStrdup (uri);
			bool raw_ret = gnome_desktop_thumbnail_has_uri(pixbuf == null ? IntPtr.Zero : pixbuf.Handle, native_uri);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_uri);
			return ret;
		}

		[DllImport("gnome-desktop-2")]
		static extern IntPtr gnome_desktop_thumbnail_scale_down_pixbuf(IntPtr pixbuf, int dest_width, int dest_height);

		public static Gdk.Pixbuf ThumbnailScaleDownPixbuf(Gdk.Pixbuf pixbuf, int dest_width, int dest_height) {
			IntPtr raw_ret = gnome_desktop_thumbnail_scale_down_pixbuf(pixbuf == null ? IntPtr.Zero : pixbuf.Handle, dest_width, dest_height);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			return ret;
		}

		[DllImport("gnome-desktop-2")]
		static extern IntPtr gnome_desktop_thumbnail_path_for_uri(IntPtr uri, int size);

		public static string ThumbnailPathForUri(string uri, Gnome.DesktopThumbnailSize size) {
			IntPtr native_uri = GLib.Marshaller.StringToPtrGStrdup (uri);
			IntPtr raw_ret = gnome_desktop_thumbnail_path_for_uri(native_uri, (int) size);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			GLib.Marshaller.Free (native_uri);
			return ret;
		}

		[DllImport("gnome-desktop-2")]
		static extern bool gnome_desktop_thumbnail_is_valid(IntPtr pixbuf, IntPtr uri, IntPtr mtime);

		public static bool ThumbnailIsValid(Gdk.Pixbuf pixbuf, string uri, System.DateTime mtime) {
			IntPtr native_uri = GLib.Marshaller.StringToPtrGStrdup (uri);
			bool raw_ret = gnome_desktop_thumbnail_is_valid(pixbuf == null ? IntPtr.Zero : pixbuf.Handle, native_uri, GLib.Marshaller.DateTimeTotime_t (mtime));
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_uri);
			return ret;
		}

		[DllImport("gnome-desktop-2")]
		static extern IntPtr gnome_desktop_thumbnail_md5(IntPtr uri);

		public static string ThumbnailMd5(string uri) {
			IntPtr native_uri = GLib.Marshaller.StringToPtrGStrdup (uri);
			IntPtr raw_ret = gnome_desktop_thumbnail_md5(native_uri);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			GLib.Marshaller.Free (native_uri);
			return ret;
		}

#endregion
	}
}
