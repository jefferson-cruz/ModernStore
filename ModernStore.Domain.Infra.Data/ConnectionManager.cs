using ModernStore.Infra.Data.Contexts.Enums;
using System.Configuration;

namespace ModernStore.Infra.Data
{
    public static class ConnectionManager
    {
        public static string GetConnectionString(ConnectionString connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString.ToString()].ConnectionString;
        }
    }
}
