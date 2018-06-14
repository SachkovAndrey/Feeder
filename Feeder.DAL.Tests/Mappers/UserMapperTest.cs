using Feeder.DAL.Mappers;
using Feeder.Db.Entities;
using NUnit.Framework;

namespace Feeder.DAL.Tests.Mappers
{
    [TestFixture]
    public class UserMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var user = new User(1, "John", "John@feeder.com", "url");

            var userMapper = new UserMapper();
            Core.Models.User result = userMapper.Map(user);
           
            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual("John", result.Name);
            Assert.AreEqual("John@feeder.com", result.Email);
            Assert.AreEqual("url", result.ImageUrl);
        }
    }
}