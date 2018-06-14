using Feeder.DAL.Mappers;
using Feeder.Db.Entities;
using NUnit.Framework;

namespace Feeder.DAL.Tests.Mappers
{
    [TestFixture]
    public class CommentMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var user = new User(1, "John", "John@feeder.com", "url");
            var comment = new Comment(3, "My test comment", "My test name", "John@feeder.com");

            var userMapper = new UserMapper();
            var commentMapper = new CommentMapper(userMapper);

            Core.Models.Comment result = commentMapper.Map(comment, user);

            Assert.AreEqual(3, result.PostId);
            Assert.AreEqual("My test comment", result.Text);
            Assert.AreNotEqual(null, result.User);
            Assert.AreEqual(1, result.User.UserId);
            Assert.AreEqual("John", result.User.Name);
            Assert.AreEqual("John@feeder.com", result.User.Email);
            Assert.AreEqual("url", result.User.ImageUrl);
        }
    }
}