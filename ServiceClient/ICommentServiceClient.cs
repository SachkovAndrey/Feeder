using System.Collections.Generic;
using System.Threading.Tasks;
using Feeder.Core.Models;

namespace ServiceClient
{
    public interface ICommentServiceClient
    {
        #region Methods

        Task<List<Comment>> Get(string url);

        #endregion
    }
}
