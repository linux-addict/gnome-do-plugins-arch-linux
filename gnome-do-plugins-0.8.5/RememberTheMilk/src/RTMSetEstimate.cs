// RTMSetEstimate.cs
// 
// Copyright (C) 2009 GNOME Do
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 


using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Addins;

using Do.Universe;
using Do.Platform;

namespace RememberTheMilk
{
	/// <summary>
	/// Class for the "Set Estimated Time" action.
	/// </summary>
	public class RTMSetEstimate : Act
	{
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Set Estimated Time"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Set or reset the estimated time for a task"); }
		}
		
		public override string Icon {
			get { return "task-setdue.png@" + GetType ().Assembly.FullName; }
		}
		
		public bool CheckValidTime(string timeEntered) {
			// RTM API supports units of days, hours and minutes
			string[] times = {
				"min", "mins", "minute", "minutes",
				"h", "hr", "hrs", "hour", "hours", 
				"d", "day", "days"
			};
			
			return times.Any (t => timeEntered.EndsWith (t));
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof (RTMTaskItem);
				yield return typeof (RTMTaskAttributeItem);
			}
		}
		
		public override IEnumerable<Type> SupportedModifierItemTypes {
			get {
				yield return typeof (ITextItem);
			}
		}
		
		public override bool ModifierItemsOptional {
			get { return false; }
		}
		
		public override bool SupportsItem (Item item) 
		{
			if (item is RTMTaskItem)
				return true;
			else if (item is RTMTaskAttributeItem)
				return (item as RTMTaskAttributeItem).Description == "Time Estimate";
			else
				return false;
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modifierItems) 
		{
			RTMTaskItem task = null;
			string est = String.Empty;
			
			if (items.Any ()) {
				if (items.First () is RTMTaskItem)
					task = (items.First () as RTMTaskItem);
				else if (items.First () is RTMTaskAttributeItem)
					task = (items.First () as RTMTaskAttributeItem).Parent;
			}
			
			if (modifierItems.Any ())
				est = ((modifierItems.First () as ITextItem).Text);
			
			if (!string.IsNullOrEmpty(est)) {
				if (!CheckValidTime(est)) {
					Services.Notifications.Notify (AddinManager.CurrentLocalizer.GetString ("Invalid Time format"),
						AddinManager.CurrentLocalizer.GetString ("The estimated time entered cannot be understood."),
						"rtm.png@" + GetType ().Assembly.FullName);
					yield break;
				}
			}
			
			if (task != null)
				Services.Application.RunOnThread (() => {
					RTM.SetEstimateTime (task.ListId, task.TaskSeriesId, task.Id, est);
				});
			
			yield break;
		}
	}
}
