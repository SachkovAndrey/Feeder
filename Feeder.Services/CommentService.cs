using System.Collections.Generic;
using Feeder.Core.Models;
using Feeder.DAL;

namespace Feeder.Services
{
    internal class CommentService : ICommentService
    {
        #region Static and Readonly Fields

        private readonly ICommentRepository repository;

        #endregion

        #region Constructors

        public CommentService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region ICommentService Members

        public IEnumerable<Comment> Get(int postId)
        {
            return repository.GetComments(postId);
        }

        #endregion
    }
}
