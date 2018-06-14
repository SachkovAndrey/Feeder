namespace Feeder.Core.Models
{
    public class Comment
    {
        #region Properties

        public int PostId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }

        #endregion
    }
}
