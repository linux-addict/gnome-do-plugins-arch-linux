// Service.cs 
// User: Karol Będkowski at 09:26 2008-10-24
//
//Copyright Karol Będkowski 2008
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;

using Mono.Addins;

using Do.Universe;
using Do.Platform;

namespace SystemServices {
	
	public class Service : Item {
		
		string name;
		string script;

		public const int UnknownStatusExitCode = 42;

		public Service (string name, string script) {
			this.script = script;

			if (name.Contains ("."))
				this.name = name.Substring (0, name.IndexOf ("."));
			else
				this.name = name;
		}
		
		public override string Name {
			get { return string.Format (AddinManager.CurrentLocalizer.GetString ("{0} service"), name); }
		}

		public override string Description {
			get { return string.Format (AddinManager.CurrentLocalizer.GetString ("Control system {0} service"), name); }
		}

		public override string Icon {
			get { return "applications-system";	}
		}

		public string Script {
			get { return script; }
		}

		public int GetStatus ()
		{
			try {
				Process status = new Process ();			

				status.StartInfo.FileName = Script;
				status.StartInfo.Arguments = "status";
				status.Start ();
				status.WaitForExit ();

				return status.ExitCode;
			} catch (Exception e) {
				Log.Error ("System service {0}: {1}", Script, e.Message);
				Log.Debug (e.StackTrace);
			}
			return UnknownStatusExitCode;
		}

		public string Perform (ServiceActionType action)
		{	
			Process process = new Process ();			
			
			process.StartInfo.FileName = SystemServices.SudoCommand;	
			process.StartInfo.Arguments = SystemServices.GetArgsForService (Script, action);
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;			
			process.Start ();
			
			string stdout = process.StandardOutput.ReadToEnd ();
			string stderr = process.StandardError.ReadToEnd ();
			return stdout + "\n" + stderr;
		}
		
	}
}
