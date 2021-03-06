/* DefineAction.cs
 *
 * GNOME Do is the legal property of its developers. Please refer to the
 * COPYRIGHT file distributed with this source distribution.
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
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Mono.Addins;

using Do.Universe;

namespace GNOME
{
	/// <summary>
	/// Given an ITextItem, DefineWordAction will look up the Text
	/// contents of the ITextItem using the gnome-dictionary.
	/// </summary>
	public class DefineAction : Act
	{
		/// <summary>
		/// Should match those and only those strings that can be
		/// looked up in a dictionary.
		/// YES: "war", "peace", "hoi polloi"
		/// NO: "war9", "2 + 4", "___1337__"
		/// </summary>
		const string wordPattern = @"^([^\W0-9_]+([ -][^\W0-9_]+)?)$";

		Regex wordRegex;
		
		public DefineAction ()
		{
			wordRegex = new Regex (wordPattern, RegexOptions.Compiled);
		}
		
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Define"); }
		}
		
		public override string Description
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Define a given word."); }
		}
		
		public override string Icon
		{
			get { return "accessories-dictionary"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes
		{
			get {
				return new Type[] {
					typeof (ITextItem),
				};
			}
		}

		/// <summary>
		/// Use wordRegex to determine whether item is definable.
		/// </summary>
		/// <param name="item">
		/// An <see cref="Item"/> to define.
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/> indicating whether or not Item
		/// can be defined.
		/// </returns>
		public override bool SupportsItem (Item item)
		{
			string word = null;

			if (item is ITextItem)
				word = (item as ITextItem).Text;

			return !string.IsNullOrEmpty (word) && wordRegex.IsMatch (word);
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modifierItems)
		{
			string args;

			foreach (Item item in items) {
				if (!(item is ITextItem))
					continue;

				args = string.Format ("--look-up \"{0}\"", (item as ITextItem).Text);
				System.Diagnostics.Process.Start ("gnome-dictionary", args);
			}
			return null;
		}
	}
}
