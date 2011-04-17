using System.Linq;

using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

using Web.Core;

namespace Web
{
	public class WebRole : RoleEntryPoint
	{
		public override bool OnStart()
		{
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");
			RoleEnvironment.Changing += RoleEnvironmentChanging;

			GlobalSetup.InitIfNeeded();

			return base.OnStart();
		}

		void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
		{
			// If a configuration setting is changing
			if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
			{
				// Set e.Cancel to true to restart this role instance
				e.Cancel = true;
			}
		}
	}
}