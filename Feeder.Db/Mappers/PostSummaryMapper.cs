using Feeder.Common;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Mappers
{
    internal class PostSummaryMapper : IMapToNew<PostSummary, Entities.PostSummary>
    {
        #region IMapToNew<PostSummary,PostSummary> Members

        public Entities.PostSummary Map(PostSummary source)
        {
            return new Entities.PostSummary(source.Id, source.Title);
        }

        #endregion
    }
}
