using System.Collections.Generic;
using System.Threading.Tasks;
using Caliburn.Micro;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;
using Feeder.ServiceClient;
using Feeder.WpfApp.ProgressBar;
using Feeder.WpfApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace Feeder.WpfApp.Tests.ViewModels
{
    [TestFixture()]
    public class PostDetailsViewModelTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            comments = new List<Comment>()
            {
                new Comment()
                {
                    PostId = 1,
                    Text = "Txt",
                    User = new User() { Email = "a@.com", ImageUrl = "url", Name = "John", UserId = 1 }
                },
                new Comment()
                {
                    PostId = 1,
                    Text = "Foo",
                    User = new User() { Email = "a@.com", ImageUrl = "url", Name = "John", UserId = 1 }
                },
                new Comment()
                {
                    PostId = 2,
                    Text = "Bar",
                    User = new User() { Email = "bb@.com", ImageUrl = "url", Name = "Bill", UserId = 2 }
                }
            };

            post = new Post()
            {
                Body = "Body",
                Id = 1,
                Title = "Test",
                User = new User() { Email = "bb@.com", ImageUrl = "url", Name = "Bill", UserId = 2 }
            };

            commentServiceClientMock = new Mock<ICommentServiceClient>();
            postServiceClientMock = new Mock<IPostServiceClient>();
            progressBarMock = new Mock<IProgressBar>();
            windowManagerMock = new Mock<IWindowManager>();
        }

        [TearDown]
        public void TearDown()
        {
            comments = null;
            post = null;

            commentServiceClientMock = null;
            postServiceClientMock = null;
            progressBarMock = null;
            windowManagerMock = null;
        }

        #endregion

        private List<Comment> comments;
        private Mock<ICommentServiceClient> commentServiceClientMock;
        private Mock<IPostServiceClient> postServiceClientMock;
        private Mock<IProgressBar> progressBarMock;
        private Mock<IWindowManager> windowManagerMock;
        private Post post;

        [Test]
        public void LoadCommentsProgressBarCallsSuccessTest()
        {
            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadComments(null);

            progressBarMock.Verify(x => x.Show(), Times.Exactly(1));
        }

        [Test]
        public void LoadCommentsSuccessTest()
        {
            commentServiceClientMock.Setup(summariesService => summariesService.Get(It.IsAny<string>())).Returns(() =>
            {
                var task = new Task<List<Comment>>(() => comments);

                task.Start();
                task.Wait();
                return task;
            });

            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadComments(null);

            Assert.AreNotEqual(null, viewModel.Comments);
            Assert.AreNotEqual(0, viewModel.Comments.Count);
            Assert.AreEqual(comments.Count, viewModel.Comments.Count);
        }

        [Test]
        public void LoadCommentsThrowExceptionSuccessTest()
        {
            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            postServiceClientMock.Setup(x => x.Get(It.IsAny<string>())).Throws(new ConnectionTimeoutException());

            viewModel.LoadComments(null);

            windowManagerMock.Verify(x => x.ShowDialog(It.IsAny<object>(), null, null), Times.Exactly(1));
        }

        [Test]
        public void LoadPostProgressBarCallsSuccessTest()
        {
            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadPost();

            progressBarMock.Verify(x => x.Show(), Times.Exactly(1));
        }

        [Test]
        public void LoadPostSussessTest()
        {
            postServiceClientMock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                var task = new Task<Post>(() => post);
                task.Start();
                task.Wait();
                return task;
            });

            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadPost();

            Assert.AreNotEqual(null, viewModel.Post);
            Assert.AreEqual(post.Id, viewModel.Post.Id);
            Assert.AreEqual(post.Title, viewModel.Post.Title);
            Assert.AreEqual(post.Body, viewModel.Post.Body);
            Assert.AreEqual(post.User.UserId, viewModel.Post.User.UserId);
        }

        [Test]
        public void LoadPostThrowExceptionSuccessTest()
        {
            var viewModel = new PostDetailsViewModel(null,
                postServiceClientMock.Object,
                commentServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            postServiceClientMock.Setup(x => x.Get(It.IsAny<string>())).Throws(new ConnectionTimeoutException());

            viewModel.LoadPost();

            windowManagerMock.Verify(x => x.ShowDialog(It.IsAny<object>(), null, null), Times.Exactly(1));
        }
    }
}
