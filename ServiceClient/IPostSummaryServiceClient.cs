using System.Collections.Generic;
using System.Threading.Tasks;
using Feeder.Core.Models;

namespace ServiceClient
{
    public interface IPostSummaryServiceClient
    {
        #region Methods

        Task<List<PostSummary>> Get(string url);

        #endregion
    }
}
