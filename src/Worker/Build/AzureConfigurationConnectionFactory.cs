using System;
using System.Configuration;
using System.Data.Common;

using EventStore.Persistence.SqlPersistence;

using Lokad.Cqrs.Build;

namespace Worker.Build
{
    internal class AzureConfigurationConnectionFactory : ConfigurationConnectionFactory
    {
        private readonly string connectionName;

        public AzureConfigurationConnectionFactory(string connectionName) : base(connectionName)
        {
            this.connectionName = connectionName;
        }

        protected override System.Data.IDbConnection Open(Guid streamId, string connectionName)
        {
            var setting = Settings;
            var factory = DbProviderFactories.GetFactory(setting.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = this.BuildConnectionString(streamId, setting);
            connection.Open();
            return connection;
        }

        public override ConnectionStringSettings Settings
        {
            get
            {
                var provider = new CloudSettingsProvider();

                string connectionString = provider.GetString(connectionName)
                    .ExposeException("{0} was not found in the role configuration.", connectionName);

                var settings = new ConnectionStringSettings
                {
                    ProviderName = "System.Data.SqlClient",
                    Name = connectionName,
                    ConnectionString = connectionString
                };

                return settings;
            }
        }
    }
}