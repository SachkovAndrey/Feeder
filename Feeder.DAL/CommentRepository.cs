using System.Collections.Generic;
using System.Linq;
using Feeder.Common;
using Feeder.Db;
using Feeder.Db.Entities;

namespace Feeder.DAL
{
    internal class CommentRepository : ICommentRepository
    {
        #region Static and Readonly Fields

        private readonly IMapToNewWithChild<Comment, User, Core.Models.Comment> commentMapper;
        private readonly IDbContext dbContext;

        #endregion

        #region Constructors

        public CommentRepository(IDbContext dbContext, IMapToNewWithChild<Comment, User, Core.Models.Comment> commentMapper)
        {
            this.dbContext = dbContext;
            this.commentMapper = commentMapper;
        }

        #endregion

        #region ICommentRepository Members

        public IEnumerable<Core.Models.Comment> GetComments(int postId)
        {
            var result = new List<Core.Models.Comment>();
            IList<Comment> comments = dbContext.GetComments(postId);

            foreach (Comment comment in comments)
            {
                User user = dbContext.GetUsers().First(x => x.Email == comment.CommenterEmail);
                result.Add(commentMapper.Map(comment, user));
            }

            return result;
        }

        #endregion
    }
}
