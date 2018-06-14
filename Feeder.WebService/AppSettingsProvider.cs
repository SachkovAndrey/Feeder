using System.Configuration;

namespace Feeder.WebService
{
    internal static class AppSettingsProvider
    {
        #region Static and Readonly Fields

        private static string connectionString;

        #endregion

        #region Static Methods

        public static string GetConnectionString()
        {
            connectionString = connectionString ?? ConfigurationManager.AppSettings["ConnectionString"];

            return connectionString;
        }

        #endregion
    }
}
