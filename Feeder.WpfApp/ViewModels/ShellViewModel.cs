using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using Caliburn.Micro;
using Feeder.WpfApp.ProgressBar;

namespace Feeder.WpfApp.ViewModels
{
    public class ShellViewModel : Screen, IProgressBar
    {
        #region Static and Readonly Fields

        private readonly SimpleContainer container;

        #endregion

        #region Fields

        
        private bool isBusy;

        private INavigationService navigationService;

        #endregion

        #region Constructors

        public ShellViewModel(SimpleContainer container)
        {
            this.container = container;

            ProgressBarTokens = new ObservableCollection<IProgressBarToken>();
            ProgressBarTokens.CollectionChanged += OnProgressBarTokensCollectionChanged;
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            private set
            {
                if (value == isBusy)
                {
                    return;
                }

                isBusy = value;
                NotifyOfPropertyChange(nameof(IsBusy));
            }
        }

        private ObservableCollection<IProgressBarToken> ProgressBarTokens { get; }

        #endregion

        #region Methods

        public void RegisterFrame(Frame frame)
        {
            navigationService = new FrameAdapter(frame);

            container.Instance(navigationService);
            container.Instance<IProgressBar>(this);

            navigationService.For<IntroViewModel>().Navigate();
        }

        #endregion

        #region IProgressBar Members

        public IProgressBarToken Show()
        {
            return new ProgressBarToken(ProgressBarTokens);
        }

        #endregion

        #region Event Handling

        private void OnProgressBarTokensCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IsBusy = ProgressBarTokens.Count != 0;
        }

        #endregion
    }
}
