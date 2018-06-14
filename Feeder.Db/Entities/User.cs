namespace Feeder.Db.Entities
{
    public class User
    {
        #region Constructors

        public User(int userId, string name, string email, string imageUrl)
        {
            UserId = userId;
            Name = name;
            Email = email;
            ImageUrl = imageUrl;
        }

        #endregion

        #region Properties

        public string Email { get; private set; }
        public string ImageUrl { get; private set; }
        public string Name { get; private set; }
        public int UserId { get; private set; }

        #endregion
    }
}
