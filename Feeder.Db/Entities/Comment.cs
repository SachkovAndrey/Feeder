namespace Feeder.Db.Entities
{
    public class Comment
    {
        #region Constructors

        public Comment(int postId, string comment, string name, string email)
        {
            PostId = postId;
            Text = comment;
            CommenterName = name;
            CommenterEmail = email;
        }

        #endregion

        #region Properties

        public string CommenterEmail { get; private set; }
        public string CommenterName { get; private set; }
        public int PostId { get; private set; }
        public string Text { get; private set; }

        #endregion
    }
}
