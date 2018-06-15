using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using Feeder.Common.Extensions;
using Feeder.Core.Models;
using Feeder.WpfApp.Commands;
using Feeder.WpfApp.ProgressBar;
using Feeder.WpfApp.Reactives;
using Flurl;
using ServiceClient;

namespace Feeder.WpfApp.ViewModels
{
    public class PostListViewModel : Screen
    {
        #region Static and Readonly Fields

        private readonly IReactiveLoader loader;

        private readonly INavigationService navigationService;
        private readonly IProgressBar progressBar;
        private readonly IPostSummaryServiceClient serviceClient;

        private readonly IWindowManager vmManager;

        #endregion

        #region Fields

        private ObservableCollection<PostSummary> filteredPostSummaries;

        private string filterText;
        private ObservableCollection<PostSummary> postSummaries;
        private ReactiveObserver<IEnumerable<PostSummary>> reactiveObserver;

        #endregion

        #region Constructors

        public PostListViewModel(INavigationService navigationService,
            IPostSummaryServiceClient serviceClient,
            IWindowManager vmManager,
            IProgressBar progressBar,
            IReactiveLoader loader)
        {
            this.navigationService = navigationService;
            this.serviceClient = serviceClient;
            this.vmManager = vmManager;
            this.progressBar = progressBar;
            this.loader = loader;

            PostSummaries = new ObservableCollection<PostSummary>();

            ObserverInitialize();
        }

        #endregion

        #region Properties

        public ObservableCollection<PostSummary> FilteredPostSummaries
        {
            get
            {
                return filteredPostSummaries;
            }
            private set
            {
                filteredPostSummaries = value;
                NotifyOfPropertyChange(nameof(FilteredPostSummaries));
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                if (value != filterText)
                {
                    filterText = value;

                    Filtrate();
                    NotifyOfPropertyChange(nameof(FilterText));
                }
            }
        }

        public ICommand GoToPostCommand => new Command(GoToPost);

        public ObservableCollection<PostSummary> PostSummaries
        {
            get
            {
                return postSummaries;
            }
            internal set
            {
                postSummaries = value;
                filteredPostSummaries = value;

                NotifyOfPropertyChange(nameof(PostSummaries));
                NotifyOfPropertyChange(nameof(FilteredPostSummaries));
            }
        }

        private ICommand LoadDataCommand => new Command(LoadData);

        #endregion

        #region Methods

        protected override void OnActivate()
        {
            base.OnActivate();

            LoadData(null);

            loader.RegisterObserver(reactiveObserver);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            loader.Dispose();
        }

        internal async void LoadData(object parameter)
        {
            try
            {
                List<PostSummary> result;
                using (progressBar.Show())
                {
                    result = await GetData();
                }

                PostSummaries = new ObservableCollection<PostSummary>(result);
            }
            catch (Exception e)
            {
                vmManager.ShowDialog(new ErrorViewModel(LoadDataCommand, e.Message));
            }
        }

        private Url BuildUrlToEndpoint()
        {
            string host = AppSettingsProvider.GetBaseAdress();
            return host.AppendPathSegment(AppSettingsProvider.GetPostSummariesEndPoint());
        }

        private void Filtrate()
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                FilteredPostSummaries = new ObservableCollection<PostSummary>(PostSummaries);
                return;
            }

            IEnumerable<PostSummary> rusult = PostSummaries.Where(x => x.Title.Contains(FilterText, StringComparison.OrdinalIgnoreCase));
            FilteredPostSummaries = new ObservableCollection<PostSummary>(rusult);
        }

        private async Task<List<PostSummary>> GetData()
        {
            return await serviceClient.Get(BuildUrlToEndpoint());
        }

        private void GoToPost(object parameter)
        {
            navigationService.For<PostDetailsViewModel>().WithParam(x => x.Id, parameter).Navigate();
        }

        private void ObserverInitialize()
        {
            reactiveObserver = new ReactiveObserver<IEnumerable<PostSummary>>(async () => await GetData(),
                (data) =>
                {
                    if (PostSummaries.Count != data.Count())
                    {
                        PostSummaries = new ObservableCollection<PostSummary>(data);
                    }
                });
        }

        #endregion
    }
}
