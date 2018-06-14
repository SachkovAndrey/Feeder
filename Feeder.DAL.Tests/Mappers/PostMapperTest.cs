using Feeder.DAL.Mappers;
using Feeder.Db.Entities;
using NUnit.Framework;

namespace Feeder.DAL.Tests.Mappers
{
    [TestFixture]
    public class PostMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var user = new User(1, "John", "John@feeder.com", "url");
            var post = new Post(2, 1, "My test post", "My test Body");

            var userMapper = new UserMapper();
            var postMapper = new PostMapper(userMapper);

            Core.Models.Post result = postMapper.Map(post, user);

            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("My test post", result.Title);
            Assert.AreEqual("My test Body", result.Body);
            Assert.AreNotEqual(null, result.User);
            Assert.AreEqual(1, result.User.UserId);
            Assert.AreEqual("John", result.User.Name);
            Assert.AreEqual("John@feeder.com", result.User.Email);
            Assert.AreEqual("url", result.User.ImageUrl);
        }
    }
}
