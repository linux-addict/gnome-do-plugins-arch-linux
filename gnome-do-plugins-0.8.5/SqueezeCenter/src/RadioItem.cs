//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using Do.Universe;

namespace SqueezeCenter
{
	public abstract class RadioItem : SqueezeCenterItem
	{
		protected RadioSubItem[] children;
				
		public virtual RadioSubItem[] Children
		{
			get { return children; }
			set {
				System.Threading.Interlocked.Exchange<RadioSubItem[]> (ref children, value);				
			}
		}
		
		public abstract RadioItem Parent {get;}
		
		public override string Icon
		{
			get { return "radio.png@" + this.GetType ().Assembly.FullName; }			
		}		
		
		public override abstract string Name { get; }
		public override abstract string Description { get; }
	}
		
	public class RadioSuperItem : RadioItem
	{		
		readonly string cmd, name;
		bool childrenSet = false;
		
		public RadioSuperItem (string cmd, string name)
		{
			this.cmd = cmd;
			this.name = name;
			this.children = new RadioSubItem[0];
		}
		
		public string Command {
			get {				
				return cmd;
			}
		}
						
		public override string Name {
			get {
				return name;
			}
		}
			
		public override string Description {
			get {
				return "Radio" ;
			}
		}
		
		public override RadioSubItem[] Children {
			get { return base.Children; }
			set {
				base.Children = value;
				childrenSet = true;
			}
		}

		public bool IsLoadedRecursive
		{
			get {
				if (!childrenSet)
					return false;
				foreach (RadioSubItem rmi in children)
					if (!rmi.IsLoadedRecursive)
						return false;
				return true;
			}
		}

		public override RadioItem Parent
		{
			get { return null; }
		}

		public RadioSubItem[] GetChildrenRecursive () 
		{
			List<RadioSubItem> result = new List<RadioSubItem> ();
			foreach (RadioSubItem rmi in children) {
				result.Add (rmi);
				rmi.CopyChildrenRecursive (result);
			}
			return result.ToArray ();
		}
	}
	
	public class RadioSubItem : RadioItem
	{
		readonly int id;
		readonly RadioItem parent;
		readonly string name;
		readonly bool hasItems;
				
		public RadioSubItem (RadioItem parent, int id, string name, bool hasItems)
		{
			this.parent = parent;
			this.id = id;
			this.name = name;
			this.hasItems = hasItems;
			this.children = new RadioSubItem[0];
		}
						
		public override string Name {
			get {
				return name;
			}
		}
			
		public override string Description {
			get {
				RadioItem parent = this.parent;
				string result = string.Empty;
				while (parent != null) {
					result = parent.Name + (result.Length == 0 ? string.Empty : " → " + result);
					parent = parent.Parent;
				}
				return result;
			}
		}

		public override RadioItem Parent
		{
			get { return parent; }
		}
		
		public int Id
		{
			get { return id; }
		}

		public bool HasItems
		{
			get { return hasItems; }
		}
		
		public RadioSuperItem GetSuper ()
		{
			RadioItem r = this;
			while (r != null) {
				if (r is RadioSuperItem)
					return r as RadioSuperItem;
				r = r.Parent;
			}
			return null;
		}

		public string IdPath
		{
			get {
				if (!(parent is RadioSubItem))
					return Id.ToString ();
				return string.Format ("{0}.{1}", (parent as RadioSubItem).IdPath, Id); 				
			}
		}
		
		public void CopyChildrenRecursive (List<RadioSubItem> target)
		{
			foreach (RadioSubItem rmi in children) {
				target.Add (rmi);
				rmi.CopyChildrenRecursive (target);
			}
		}
		
		public bool IsLoadedRecursive
		{
			get {
				if (hasItems)
					foreach (RadioSubItem rmi in children)
						if (!rmi.IsLoadedRecursive)
							return false;
				return true;
			}
		}
	}
}
