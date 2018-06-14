using System;
using System.Threading.Tasks;

namespace Feeder.WpfApp.Reactives
{
    public class ReactiveObserver<T> : IObserver<long>
    {
        #region Static and Readonly Fields

        private readonly Action<T> callBackAction;
        private readonly Func<Task<T>> loadAction;

        #endregion

        #region Constructors

        public ReactiveObserver(Func<Task<T>> loadAction, Action<T> callBackAction)
        {
            this.loadAction = loadAction;
            this.callBackAction = callBackAction;
        }

        #endregion

        #region IObserver<long> Members

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public async void OnNext(long value)
        {
            T data = await loadAction.Invoke();
            callBackAction.Invoke(data);
        }

        #endregion
    }
}
