using Feeder.Db.Mappers;
using NUnit.Framework;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Tests
{
    [TestFixture]
    public class CommentMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var comment = new Comment(3, "My test comment", "My test name", "John@feeder.com");
            var commentMapper = new CommentMapper();

            Entities.Comment result = commentMapper.Map(comment);

            Assert.AreEqual(3, result.PostId);
            Assert.AreEqual("My test comment", result.Text);
            Assert.AreEqual("John@feeder.com", result.CommenterEmail);
            Assert.AreEqual("My test name", result.CommenterName);
        }
    }
}
