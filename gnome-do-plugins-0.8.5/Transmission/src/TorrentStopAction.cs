
using System;
using System.Linq;
using System.Collections.Generic;

using Mono.Addins;

using Do.Universe;

namespace Transmission {
	
	public class TorrentStopAction: Act {
		
		public TorrentStopAction() {
		}
		
	    public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Stop"); }
	    }
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Stop downloading torrent"); }
		}
		
		public override string Icon {
			get { return "gtk-media-pause"; }
		}
			
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (TorrentItem); }
		}
    
		public override IEnumerable<Item> Perform(IEnumerable<Item> items, IEnumerable<Item> modItems) {
			TransmissionAPI api = TransmissionPlugin.getTransmission();

			var hashes = items.Cast<TorrentItem>().Select(t => t.HashString);
			api.StopTorrents(hashes);
			
			return null;
		}
	}
}
