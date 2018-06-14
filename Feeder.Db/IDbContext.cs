using System.Collections.Generic;
using Feeder.Db.Entities;

namespace Feeder.Db
{
    public interface IDbContext
    {
        #region Methods

        IList<Comment> GetComments(int postId);

        Post GetPost(int postId);

        IEnumerable<PostSummary> GetPostSummaries();

        IEnumerable<User> GetUsers();

        #endregion
    }
}
