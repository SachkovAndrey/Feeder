using System.Collections.Generic;
using Feeder.Core.Models;

namespace Feeder.DAL
{
    public interface IPostSummaryRepository
    {
        #region Methods

        IEnumerable<PostSummary> GetPostSummaries();

        #endregion
    }
}
