using System.Collections.Generic;
using Feeder.Core.Models;

namespace Feeder.Services
{
    public interface IPostSummaryService
    {
        #region Methods

        IEnumerable<PostSummary> GetPostSummaries();

        #endregion
    }
}
