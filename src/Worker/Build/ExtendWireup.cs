using EventStore;

namespace Worker.Build
{
    public static class ExtendWireup
    {
        public static SqlPersistenceWireup UsingSqlAzurePersistence(this Wireup wireup, string connectionName)
        {
            var factory = new AzureConfigurationConnectionFactory(connectionName);
            return wireup.UsingSqlPersistence(factory);
        }
    }
}