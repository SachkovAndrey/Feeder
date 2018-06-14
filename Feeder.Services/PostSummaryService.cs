using System.Collections.Generic;
using Feeder.Core.Models;
using Feeder.DAL;

namespace Feeder.Services
{
    internal class PostSummaryService : IPostSummaryService
    {
        #region Static and Readonly Fields

        private readonly IPostSummaryRepository repository;

        #endregion

        #region Constructors

        public PostSummaryService(IPostSummaryRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region IPostSummaryService Members

        public IEnumerable<PostSummary> GetPostSummaries()
        {
            return repository.GetPostSummaries();
        }

        #endregion
    }
}
