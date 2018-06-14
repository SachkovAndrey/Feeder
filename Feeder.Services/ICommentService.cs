using System.Collections.Generic;
using Feeder.Core.Models;

namespace Feeder.Services
{
    public interface ICommentService
    {
        #region Methods

        IEnumerable<Comment> Get(int postId);

        #endregion
    }
}
