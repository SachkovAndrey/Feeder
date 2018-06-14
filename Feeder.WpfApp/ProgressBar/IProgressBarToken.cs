using System;

namespace Feeder.WpfApp.ProgressBar
{
    public interface IProgressBarToken : IDisposable
    {
        #region Properties

        Guid TokenId { get; }

        #endregion
    }
}
