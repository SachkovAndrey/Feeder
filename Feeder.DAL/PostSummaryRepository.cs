using System.Collections.Generic;
using System.Linq;
using Feeder.Common;
using Feeder.Db;
using Feeder.Db.Entities;

namespace Feeder.DAL
{
    internal class PostSummaryRepository : IPostSummaryRepository
    {
        #region Static and Readonly Fields

        private readonly IDbContext dbContext;
        private readonly IMapToNew<PostSummary, Core.Models.PostSummary> postSummaryMapper;

        #endregion

        #region Constructors

        public PostSummaryRepository(IDbContext dbContext, IMapToNew<PostSummary, Core.Models.PostSummary> postSummaryMapper)
        {
            this.dbContext = dbContext;
            this.postSummaryMapper = postSummaryMapper;
        }

        #endregion

        #region IPostSummaryRepository Members

        public IEnumerable<Core.Models.PostSummary> GetPostSummaries()
        {
            IEnumerable<PostSummary> summaries = dbContext.GetPostSummaries();
            return summaries.Select(x => postSummaryMapper.Map(x)).ToList();
        }

        #endregion
    }
}
