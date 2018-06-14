using Feeder.Common;
using Feeder.Db.Entities;

namespace Feeder.DAL.Mappers
{
    internal class CommentMapper : IMapToNewWithChild<Comment, User, Core.Models.Comment>
    {
        #region Static and Readonly Fields

        private readonly IMapToNew<User, Core.Models.User> userMapper;

        #endregion

        #region Constructors

        public CommentMapper(IMapToNew<User, Core.Models.User> userMapper)
        {
            this.userMapper = userMapper;
        }

        #endregion

        #region IMapToNewWithChild<Comment,User,Comment> Members

        public Core.Models.Comment Map(Comment source, User childSource)
        {
            return new Core.Models.Comment() { PostId = source.PostId, User = userMapper.Map(childSource), Text = source.Text };
        }

        #endregion
    }
}
