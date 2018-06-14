namespace Feeder.Core.Models
{
    public class Post
    {
        #region Properties

        public string Body { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }

        #endregion
    }
}
