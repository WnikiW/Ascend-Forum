using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Ganss.Xss;

namespace Ascend_Forum.Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        private Mock<AscendForumDbContext> _mockContext;
        private Mock<IHtmlSanitizer> _mockSanitizer;
        private PostService _service;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AscendForumDbContext>(new DbContextOptions<AscendForumDbContext>());
            _mockSanitizer = new Mock<IHtmlSanitizer>();
            _service = new PostService(_mockContext.Object, _mockSanitizer.Object);

            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>(), It.IsAny<string>(), null))
                .Returns((string s, string b, string f) => s);
        }

        [Test]
        public void CreatePost_ShouldAdd_WhenCategoryExists()
        {
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category> { new Category { Id = 1 } });
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post>());

            _service.CreatePost("Title", "Content", 1, "user1");

            _mockContext.Verify(c => c.Posts.Add(It.IsAny<Post>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void CreatePost_ShouldThrow_WhenCategoryDoesNotExist()
        {
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category>());

            Assert.Throws<ArgumentException>(() => _service.CreatePost("Title", "Content", 1, "user1"));
        }

        [Test]
        public void GetPostDetails_ShouldReturnDetails_WhenPostExists()
        {
            var creator = new User { Id = "u1", AscendName = "Creator" };
            var post = new Post { Id = 1, Title = "Post 1", Creator = creator };
            var comment = new Comment { Id = 10, PostId = 1, Creator = creator };
            var reaction = new CommentReaction { CommentId = 10, UserId = "u1", ReactionType = ReactionType.ThumbsUp };

            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post> { post });
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment> { comment });
            _mockContext.Setup(c => c.CommentReactions).ReturnsDbSet(new List<CommentReaction> { reaction });

            var result = _service.GetPostDetails(1, "u1");

            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo("Post 1"));
                Assert.That(result.Comments.First().CurrentUserReaction, Is.EqualTo(ReactionType.ThumbsUp));
            });
        }
    }
}