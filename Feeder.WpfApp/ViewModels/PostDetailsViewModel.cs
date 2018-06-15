using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using Feeder.Core.Models;
using Feeder.WpfApp.Commands;
using Feeder.WpfApp.ProgressBar;
using Feeder.WpfApp.Reactives;
using Flurl;
using ServiceClient;

namespace Feeder.WpfApp.ViewModels
{
    public class PostDetailsViewModel : Screen
    {
        #region Static and Readonly Fields

        private readonly ICommentServiceClient commentServiceClient;

        private readonly IReactiveLoader loader;
        private readonly INavigationService navigationService;

        private readonly IProgressBar progressBar;
        private readonly IPostServiceClient serviceClient;
        private readonly IWindowManager windowManager;

        #endregion

        #region Fields

        private ObservableCollection<Comment> comments;

        private Post post;
        private ReactiveObserver<IEnumerable<Comment>> reactiveObserver;

        #endregion

        #region Constructors

        public PostDetailsViewModel(INavigationService navigationService,
            IPostServiceClient serviceClient,
            ICommentServiceClient commentServiceClient,
            IWindowManager windowManager,
            IProgressBar progressBar,
            IReactiveLoader loader)
        {
            this.navigationService = navigationService;
            this.serviceClient = serviceClient;
            this.commentServiceClient = commentServiceClient;
            this.windowManager = windowManager;
            this.progressBar = progressBar;
            this.loader = loader;

            Comments = new ObservableCollection<Comment>();
            ObserverInitialize();
        }

        #endregion

        #region Properties

        public ObservableCollection<Comment> Comments
        {
            get
            {
                return comments;
            }
            private set
            {
                comments = value;
                NotifyOfPropertyChange(nameof(Comments));
            }
        }

        public ICommand GoBackCommand => new Command(GoBack);

        public int Id { get; set; }

        public Post Post
        {
            get
            {
                return post;
            }
            set
            {
                post = value;
                NotifyOfPropertyChange(nameof(Post));
            }
        }

        private ICommand LoadCommentsCommand => new Command(LoadComments);

        #endregion

        #region Methods

        protected override void OnActivate()
        {
            base.OnActivate();

            LoadPost();
            LoadComments(null);
            loader.RegisterObserver(reactiveObserver);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            loader.Dispose();
        }

        internal async void LoadComments(object parameter)
        {
            try
            {
                List<Comment> result;
                using (progressBar.Show())
                {
                    result = await LoadCommentsAsync();
                }
                Comments = new ObservableCollection<Comment>(result);
            }
            catch (Exception e)
            {
                windowManager.ShowDialog(new ErrorViewModel(LoadCommentsCommand, e.Message));
            }
        }

        internal async void LoadPost()
        {
            try
            {
                Post result;
                using (progressBar.Show())
                {
                    result = await serviceClient.Get(BuildUrlToPostEndpoint());
                }

                Post = result;
            }
            catch (Exception e)
            {
                windowManager.ShowDialog(new ErrorViewModel(GoBackCommand, e.Message));
            }
        }

        private Url BuildUrlToCommentEndpoint()
        {
            string host = AppSettingsProvider.GetBaseAdress();
            return host.AppendPathSegment(AppSettingsProvider.GetCommentsEndPoint()).SetQueryParams(new { Id = Id.ToString() });
        }

        private Url BuildUrlToPostEndpoint()
        {
            string host = AppSettingsProvider.GetBaseAdress();
            return host.AppendPathSegment(AppSettingsProvider.GetPostEndPoint()).SetQueryParams(new { Id = Id.ToString() });
        }

        private void GoBack(object parameter)
        {
            navigationService.For<PostListViewModel>().Navigate();
        }

        private async Task<List<Comment>> LoadCommentsAsync()
        {
            return await commentServiceClient.Get(BuildUrlToCommentEndpoint());
        }

        private void ObserverInitialize()
        {
            reactiveObserver = new ReactiveObserver<IEnumerable<Comment>>(async () => await LoadCommentsAsync(),
                (data) =>
                {
                    if (Comments.Count != data.Count())
                    {
                        Comments = new ObservableCollection<Comment>(data);
                    }
                });
        }

        #endregion
    }
}
