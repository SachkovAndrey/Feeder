namespace Feeder.Db.Entities
{
    public class Post
    {
        #region Constructors

        public Post(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }

        #endregion

        #region Properties

        public string Body { get; private set; }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public int UserId { get; private set; }

        #endregion
    }
}
