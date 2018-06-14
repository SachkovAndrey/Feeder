using Feeder.Common;
using Feeder.WebService;

namespace Feeder.WebServices
{
    public class Configuration : IConfiguration
    {
        #region IConfiguration Members

        public string ConnectionString
        {
            get
            {
                return AppSettingsProvider.GetConnectionString();
            }
        }

        #endregion
    }
}
