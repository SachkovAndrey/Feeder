using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Feeder.WpfApp.Reactives
{
    public class ReactiveLoader : IReactiveLoader
    {
        #region Static and Readonly Fields

        private readonly IList<IDisposable> observers;

        private readonly IObservable<long> scheduledTimer;

        #endregion

        #region Constructors

        public ReactiveLoader()
        {
            observers = new List<IDisposable>();
            scheduledTimer = Observable.Interval(TimeSpan.FromSeconds(int.Parse(AppSettingsProvider.GetObservableScheduleInterval())),
                DispatcherScheduler.Current);
        }

        #endregion

        #region IReactiveLoader Members

        public void Dispose()
        {
            foreach (IDisposable disposable in observers)
            {
                disposable.Dispose();
            }
        }

        public void RegisterObserver(IObserver<long> observer)
        {
            IDisposable createdObserver = scheduledTimer.Subscribe(observer);

            observers.Add(createdObserver);
        }

        #endregion
    }
}
