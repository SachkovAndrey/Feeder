using System.Windows.Input;
using Caliburn.Micro;
using Feeder.WpfApp.Commands;

namespace Feeder.WpfApp.ViewModels
{
    public class IntroViewModel : Screen
    {
        #region Static and Readonly Fields

        private readonly INavigationService navigationService;

        #endregion

        #region Constructors

        public IntroViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        #endregion

        #region Properties

        public ICommand OkCommand => new Command(Ok);

        #endregion

        #region Methods

        private void Ok(object parameter)
        {
            navigationService.For<PostListViewModel>().Navigate();
        }

        #endregion
    }
}
