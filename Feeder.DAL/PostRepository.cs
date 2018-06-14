using System.Linq;
using Feeder.Common;
using Feeder.Db;
using Feeder.Db.Entities;

namespace Feeder.DAL
{
    internal class PostRepository : IPostRepository
    {
        #region Static and Readonly Fields

        private readonly IDbContext dbContext;
        private readonly IMapToNewWithChild<Post, User, Core.Models.Post> postMapper;

        #endregion

        #region Constructors

        public PostRepository(IDbContext dbContext, IMapToNewWithChild<Post, User, Core.Models.Post> postMapper)
        {
            this.dbContext = dbContext;
            this.postMapper = postMapper;
        }

        #endregion

        #region IPostRepository Members

        public Core.Models.Post GetPost(int postId)
        {
            Post post = dbContext.GetPost(postId);
            User user = dbContext.GetUsers().First(x => x.UserId == post.UserId);

            return postMapper.Map(post, user);
        }

        #endregion
    }
}
