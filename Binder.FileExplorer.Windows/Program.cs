using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ApplicationInsights;

namespace Binder.Windows.FileExplorer
{
	static class Program
	{
	    public static TelemetryClient TelemetryClient = new TelemetryClient();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

            TelemetryClient.Context.Properties["MachineName"] = System.Environment.MachineName;

            TelemetryClient.TrackEvent("Started");
            
            

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LoginPage());
		}
	}
}
