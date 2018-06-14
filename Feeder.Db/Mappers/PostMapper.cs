using Feeder.Common;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Mappers
{
    internal class PostMapper : IMapToNew<Post, Entities.Post>
    {
        #region IMapToNew<Post,Post> Members

        public Entities.Post Map(Post source)
        {
            return new Entities.Post(source.Id, source.UserId, source.Title, source.Body);
        }

        #endregion
    }
}
