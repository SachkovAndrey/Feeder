using System;
using System.Collections.Generic;
using System.Linq;
using Feeder.Common;
using Feeder.Common.Exceptions;
using Org.Feeder.FeederDb;

namespace Feeder.Db
{
    internal class DbContext : IDbContext
    {
        #region Static and Readonly Fields

        private readonly IMapToNew<Comment, Entities.Comment> commentMapper;

        private readonly IDataBaseFactory dataBaseFactory;

        private readonly IMapToNew<Post, Entities.Post> postMapper;
        private readonly IMapToNew<PostSummary, Entities.PostSummary> postSummaryMapper;
        private readonly IMapToNew<User, Entities.User> userMapper;

        #endregion

        #region Constructors

        public DbContext(IDataBaseFactory dataBaseFactory,
            IMapToNew<Post, Entities.Post> postMapper,
            IMapToNew<PostSummary, Entities.PostSummary> postSummaryMapper,
            IMapToNew<Comment, Entities.Comment> commentMapper,
            IMapToNew<User, Entities.User> userMapper)
        {
            this.dataBaseFactory = dataBaseFactory;
            this.postMapper = postMapper;
            this.commentMapper = commentMapper;
            this.userMapper = userMapper;
            this.postSummaryMapper = postSummaryMapper;
        }

        #endregion

        #region IDbContext Members

        public IList<Entities.Comment> GetComments(int postId)
        {
            try
            {
                Database db = dataBaseFactory.Create();
                IList<Comment> result = db.GetComments(postId);
                return result.Select(x => commentMapper.Map(x)).ToList();
            }
            catch (Exception)
            {
                throw new ConnectionTimeoutException();
            }
        }

        public Entities.Post GetPost(int postId)
        {
            try
            {
                Database db = dataBaseFactory.Create();
                Post result = db.GetPost(postId);
                return postMapper.Map(result);
            }
            catch (Exception)
            {
                throw new ConnectionTimeoutException();
            }
        }

        public IEnumerable<Entities.PostSummary> GetPostSummaries()
        {
            try
            {
                Database db = dataBaseFactory.Create();
                IEnumerable<PostSummary> result = db.GetPostSummaries();
                return result.Select(x => postSummaryMapper.Map(x)).ToList();
            }
            catch (Exception)
            {
                throw new ConnectionTimeoutException();
            }
        }

        public IEnumerable<Entities.User> GetUsers()
        {
            try
            {
                Database db = dataBaseFactory.Create();
                IEnumerable<User> result = db.GetUsers();
                return result.Select(x => userMapper.Map(x)).ToList();
            }
            catch (Exception)
            {
                throw new ConnectionTimeoutException();
            }
        }

        #endregion
    }
}
