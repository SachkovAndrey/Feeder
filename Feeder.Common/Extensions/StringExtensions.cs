using System;

namespace Feeder.Common.Extensions
{
    public static class StringExtensions
    {
        #region Static Methods

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        #endregion
    }
}
