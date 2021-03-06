// MountAction.cs
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
using System.Linq;

using Mono.Addins;

using Do.Universe;
using Do.Platform;

namespace DiskMounter
{
	public class MountAction : Act
	{
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Mount"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Mount volume"); }
		}
		
		public override string Icon {
			get { return "harddrive"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (DriveItem); }
		}
                
		public override bool SupportsItem (Item item) 
		{
			return !(item as DriveItem).IsMounted;
		}
                
		public override bool SupportsModifierItemForItems (IEnumerable<Item> items, Item modItem)
		{
			return false;
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			Services.Application.RunOnThread (() => {
				(items.First () as DriveItem).Mount ();
			});
			yield break;
		}
	}
}
