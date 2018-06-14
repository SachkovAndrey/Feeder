using System.Collections.Generic;
using Feeder.Core.Models;

namespace Feeder.DAL
{
    public interface ICommentRepository
    {
        #region Methods

        IEnumerable<Comment> GetComments(int postId);

        #endregion
    }
}
