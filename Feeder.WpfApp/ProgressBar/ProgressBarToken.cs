using System;
using System.Collections.Generic;

namespace Feeder.WpfApp.ProgressBar
{
    public class ProgressBarToken : IProgressBarToken
    {
        #region Static and Readonly Fields

        private readonly ICollection<IProgressBarToken> tokens;

        #endregion

        #region Constructors

        public ProgressBarToken(ICollection<IProgressBarToken> tokens)
        {
            this.tokens = tokens;

            TokenId = Guid.NewGuid();

            lock (tokens)
            {
                tokens.Add(this);
            }
        }

        #endregion

        #region IProgressBarToken Members

        public Guid TokenId { get; }

        public void Dispose()
        {
            lock (tokens)
            {
                tokens.Remove(this);
            }
        }

        #endregion
    }
}
