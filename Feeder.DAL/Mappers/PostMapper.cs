using Feeder.Common;
using Feeder.Db.Entities;

namespace Feeder.DAL.Mappers
{
    internal class PostMapper : IMapToNewWithChild<Post, User, Core.Models.Post>
    {
        #region Static and Readonly Fields

        private readonly IMapToNew<User, Core.Models.User> userMapper;

        #endregion

        #region Constructors

        public PostMapper(IMapToNew<User, Core.Models.User> userMapper)
        {
            this.userMapper = userMapper;
        }

        #endregion

        #region IMapToNewWithChild<Post,User,Post> Members

        public Core.Models.Post Map(Post source, User childSource)
        {
            return new Core.Models.Post() { Id = source.Id, Body = source.Body, Title = source.Title, User = userMapper.Map(childSource) };
        }

        #endregion
    }
}
