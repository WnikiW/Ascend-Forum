using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Ganss.Xss;
using Ascend_Forum.Core.Common;

namespace Ascend_Forum.Tests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private Mock<AscendForumDbContext> _mockContext;
        private Mock<IHtmlSanitizer> _mockSanitizer;
        private CommentService _service;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AscendForumDbContext>(new DbContextOptions<AscendForumDbContext>());
            _mockSanitizer = new Mock<IHtmlSanitizer>();
            _service = new CommentService(_mockContext.Object, _mockSanitizer.Object);
            
            _mockSanitizer.Setup(s => s.Sanitize(It.IsAny<string>(), It.IsAny<string>(), null))
                .Returns((string s, string b, string f) => s);
        }

        [Test]
        public void CreateComment_ShouldAddComment_WhenValid()
        {
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post> { new Post { Id = 1 } });
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment>());

            _service.CreateComment("Content", 1, "user1", null);

            _mockContext.Verify(c => c.Comments.Add(It.IsAny<Comment>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void CreateComment_ShouldThrow_WhenPostDoesNotExist()
        {
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post>());

            Assert.Throws<EntityNotFoundException>(() => _service.CreateComment("Content", 1, "user1", null));
        }

        [Test]
        public void CreateComment_ShouldAddReply_WhenParentIsValid()
        {
            var post = new Post { Id = 1 };
            var parent = new Comment { Id = 10, PostId = 1 };
            
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post> { post });
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment> { parent });

            _service.CreateComment("Reply", 1, "user1", 10);

            _mockContext.Verify(c => c.Comments.Add(It.Is<Comment>(c => c.ParentId == 10)), Times.Once);
        }

        [Test]
        public void CreateComment_ShouldThrow_WhenParentBelongsToDifferentPost()
        {
            var parent = new Comment { Id = 10, PostId = 2 };
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(new List<Post> { new Post { Id = 1 } });
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment> { parent });

            Assert.Throws<ArgumentException>(() => _service.CreateComment("Reply", 1, "user1", 10));
        }
    }
}