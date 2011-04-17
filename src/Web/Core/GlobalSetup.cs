using System.Diagnostics;

using Autofac;

using Lokad.Cqrs.Build;
using Lokad.Cqrs.Build.Client;

using Messages.Commands;

namespace Web.Core
{
	public static class GlobalSetup
	{
		internal static readonly CloudClient Client;

		static GlobalSetup()
		{
			Client = Build();
		}

		public static CloudClient Build()
		{
            var builder = new CloudClientBuilder();

			builder.Serialization.UseProtoBufMessageSerializer();

            builder.Azure.LoadStorageAccountFromSettings(
                () => new CloudSettingsProvider().GetString("StorageConnectionString")
                          .ExposeException("StorageConnectionString was not found in the role configuration.")
                );
            
			builder.Domain(db =>
				{
					db.WithDefaultInterfaces();
                    db.InAssemblyOf<CreateEvent>();
                });

            builder.Builder.RegisterModule(new MvcModule());

            return builder.BuildFor("messages");
		}

		internal static void InitIfNeeded()
		{
			Trace.WriteLine("Bus running: " + Client.GetHashCode());
		}
	}
}