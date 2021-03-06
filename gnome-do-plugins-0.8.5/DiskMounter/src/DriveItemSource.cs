// DriveItemSource.cs
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, see <http://www.gnu.org/licenses/> or 
// write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, 
// Boston, MA 02111-1307 USA
//

using System;
using System.Collections.Generic;
using Gnome.Vfs;

using Do.Universe;

namespace DiskMounter {

	public class DriveItemSource : ItemSource {

		List<Item> items;
		private static VolumeMonitor monitor;
		
		public DriveItemSource ()
		{
			Vfs.Initialize ();
			monitor = Gnome.Vfs.VolumeMonitor.Get ();
			items = new List<Item> ();
		}
		
		public override string Name {
			get { return "Drives"; }
		}
		
		public override string Description {
			get { return "Available mounted and unmounted drives."; }
		}
		
		public override string Icon {
			get { return "harddrive"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (DriveItem); }
		}
		
		public override IEnumerable<Item> Items {
			get { return items; }
		}
		
		public override IEnumerable<Item> ChildrenOfItem (Item item)
		{
			yield break;
		}
		
		public override void UpdateItems ()
		{
			items.Clear ();
			
			foreach (Drive drive in monitor.ConnectedDrives){
				items.Add (new DriveItem (drive));              
			}
		}  
	}
}
