using System;

namespace Feeder.Common.Exceptions
{
    public class ConnectionTimeoutException : Exception
    {
        #region Constants

        private const string message = "Connection timeout";

        #endregion

        #region Constructors

        public ConnectionTimeoutException(string message) : base(message)
        {
        }

        public ConnectionTimeoutException() : base(message)
        {
        }

        #endregion
    }
}
