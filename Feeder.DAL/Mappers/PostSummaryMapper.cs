using Feeder.Common;
using Feeder.Db.Entities;

namespace Feeder.DAL.Mappers
{
    public class PostSummaryMapper : IMapToNew<PostSummary, Core.Models.PostSummary>
    {
        #region IMapToNew<PostSummary,PostSummary> Members

        public Core.Models.PostSummary Map(PostSummary source)
        {
            return new Core.Models.PostSummary() { Id = source.Id, Title = source.Title };
        }

        #endregion
    }
}
