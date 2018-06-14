using System;

namespace Feeder.WpfApp.Reactives
{
    public interface IReactiveLoader : IDisposable
    {
        #region Methods

        void RegisterObserver(IObserver<long> observer);

        #endregion
    }
}
