using System.Web;
using System.Web.Http;
using Feeder.WebService.Filters;
using Feeder.WebServices;
using SimpleInjector;

namespace Feeder.WebService
{
    public class WebApiApplication : HttpApplication
    {
        #region Methods

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ConnectionTimeoutFilterAttribute());

            Container container = Bootstrapper.Initialize();
        }

        #endregion
    }
}
