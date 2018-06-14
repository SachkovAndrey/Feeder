using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using Feeder.WpfApp.Reactives;
using Feeder.WpfApp.ViewModels;
using ServiceClient;

namespace Feeder.WpfApp
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Fields

        private SimpleContainer container;

        #endregion

        #region Constructors

        public Bootstrapper()
        {
            Initialize();
        }

        #endregion

        #region Methods

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Instance(container);

            container.PerRequest<IPostServiceClient, PostServiceClient>();
            container.PerRequest<IPostSummaryServiceClient, PostSummaryServiceClient>();
            container.PerRequest<ICommentServiceClient, CommentServiceClient>();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IReactiveLoader, ReactiveLoader>();

            container.PerRequest<ShellViewModel>();
            container.PerRequest<IntroViewModel>();
            container.PerRequest<PostListViewModel>();
            container.PerRequest<PostDetailsViewModel>();
            container.PerRequest<ErrorViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        #endregion

        #region Event Handling

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        #endregion
    }
}
