using System.Collections.Generic;
using System.Threading.Tasks;
using Feeder.Core.Models;

namespace Feeder.ServiceClient
{
    public interface ICommentServiceClient
    {
        #region Methods

        Task<List<Comment>> Get(string url);

        #endregion
    }
}
