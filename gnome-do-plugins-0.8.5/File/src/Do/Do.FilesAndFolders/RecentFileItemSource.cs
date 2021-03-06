/* RecentFileItemSource.cs
 *
 * GNOME Do is the legal property of its developers. Please refer to the
 * COPYRIGHT file distributed with this
 * source distribution.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Linq;
using System.Collections.Generic;

using Mono.Addins;

using Do.Universe;
using Do.Platform;

namespace Do.FilesAndFolders
{
	public class RecentFileItemSource : ItemSource
	{
		IEnumerable<Item> items;
		
		public override IEnumerable<Item> Items {
			get { return items; }
		}
		
		public RecentFileItemSource ()
		{
			items = Enumerable.Empty<Item> ();
			OnRecentChanged (this, EventArgs.Empty);
			Gtk.RecentManager.Default.Changed += OnRecentChanged;
		}
		
		void OnRecentChanged (object sender, EventArgs e)
		{
			// We update Files here because this is called on the main thread.
			// We call ToArray so that Files is immutable and safe to enumerate.
			items = GetRecentFiles ().OfType<Item> ().ToArray ();
		}

		IEnumerable<IFileItem> GetRecentFiles ()
		{
			GLib.List recent_items = new GLib.List (Gtk.RecentManager.Default.Items.Handle, typeof(Gtk.RecentInfo));
			foreach (Gtk.RecentInfo info in recent_items.Cast<Gtk.RecentInfo> ().Where (it => it.Exists ())) {
				yield return Services.UniverseFactory.NewFileItem (info.Uri);
				info.Dispose ();
			}
			recent_items.Dispose ();
			yield break;
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (IFileItem); }
		}
		
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Recent Files"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Finds recently-opened files."); }
		}
		
		public override string Icon {
			get { return "document"; }
		}
	}
}
