using Feeder.Common;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Mappers
{
    internal class CommentMapper : IMapToNew<Comment, Entities.Comment>
    {
        #region IMapToNew<Comment,Comment> Members

        public Entities.Comment Map(Comment source)
        {
            return new Entities.Comment(source.PostId, source.Text, source.CommenterName, source.CommenterEmail);
        }

        #endregion
    }
}
