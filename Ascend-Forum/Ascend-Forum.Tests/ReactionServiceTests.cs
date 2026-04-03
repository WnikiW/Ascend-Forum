using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Ascend_Forum.Core.Common;

namespace Ascend_Forum.Tests
{
    [TestFixture]
    public class ReactionServiceTests
    {
        private Mock<AscendForumDbContext> _mockContext;
        private ReactionService _service;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AscendForumDbContext>(new DbContextOptions<AscendForumDbContext>());
            _service = new ReactionService(_mockContext.Object);
        }

        [Test]
        public void React_ShouldRemove_WhenSameReactionExists()
        {
            var reaction = new CommentReaction { CommentId = 1, UserId = "u1", ReactionType = ReactionType.ThumbsUp };
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment> { new Comment { Id = 1 } });
            _mockContext.Setup(c => c.CommentReactions).ReturnsDbSet(new List<CommentReaction> { reaction });

            _service.React(1, "u1", ReactionType.ThumbsUp);

            _mockContext.Verify(c => c.CommentReactions.Remove(reaction), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void React_ShouldUpdate_WhenDifferentReactionExists()
        {
            var reaction = new CommentReaction { CommentId = 1, UserId = "u1", ReactionType = ReactionType.ThumbsUp };
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment> { new Comment { Id = 1 } });
            _mockContext.Setup(c => c.CommentReactions).ReturnsDbSet(new List<CommentReaction> { reaction });

            _service.React(1, "u1", ReactionType.Smile);

            Assert.That(reaction.ReactionType, Is.EqualTo(ReactionType.Smile));
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void React_ShouldThrow_WhenCommentDoesNotExist()
        {
            _mockContext.Setup(c => c.Comments).ReturnsDbSet(new List<Comment>());

            Assert.Throws<EntityNotFoundException>(() => _service.React(1, "u1", ReactionType.ThumbsUp));
        }
    }
}