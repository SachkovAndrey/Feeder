using System.Web.Http;
using Feeder.Common;
using Feeder.DAL;
using Feeder.Db;
using Feeder.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Feeder.WebServices
{
    internal static class Bootstrapper
    {
        #region Static Methods

        public static Container Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterSingleton<IConfiguration>(() => new Configuration());
            DbComponentRegistration.RegisterDb(container);
            RepositoryComponentRegistration.RegisterRepositories(container);
            ServicesComponentRegistrations.RegisterServices(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }

        #endregion
    }
}
