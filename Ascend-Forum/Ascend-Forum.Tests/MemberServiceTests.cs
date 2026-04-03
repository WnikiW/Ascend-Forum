using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Tests
{
    [TestFixture]
    public class MemberServiceTests
    {
        private AscendForumDbContext _context;
        private MemberService _service;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AscendForumDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AscendForumDbContext(options);
            _service = new MemberService(_context);
        }

        [TearDown]
        public void TearDown() => _context.Dispose();

        [Test]
        public void GetMembers_ShouldFilterByPostCount()
        {
            _context.Users.Add(new User { Id = "u1", UserName = "u1", AscendName = "Alpha", FirstName = "Alpha" });
            _context.Posts.AddRange(
                new Post { CreatorId = "u1", Title = "T1", Content = "C1" },
                new Post { CreatorId = "u1", Title = "T2", Content = "C2" }
            );
            _context.SaveChanges();

            var result = _service.GetMembers(minPostCount: 2);

            Assert.That(result.Members.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetMembers_ShouldFilterByReactionCount()
        {
            _context.Users.Add(new User { Id = "u1", UserName = "u1", AscendName = "Alpha", FirstName = "Alpha" });
            var comment = new Comment { Id = 1, PostId = 1, CreatorId = "u1", Content = "C" };
            _context.Comments.Add(comment);
            _context.CommentReactions.Add(new CommentReaction { CommentId = 1, UserId = "u2", ReactionType = ReactionType.ThumbsUp });
            _context.SaveChanges();

            var result = _service.GetMembers(minReactionCount: 1);

            Assert.That(result.Members.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetMembers_ShouldReturnPaginatedResult()
        {
            for (int i = 0; i < 15; i++)
                _context.Users.Add(new User { Id = $"u{i}", UserName = $"u{i}", AscendName = $"User{i}", FirstName = "First" });
            _context.SaveChanges();

            var result = _service.GetMembers(pageNumber: 2, pageSize: 10);

            Assert.Multiple(() =>
            {
                Assert.That(result.Members.Count(), Is.EqualTo(5));
                Assert.That(result.TotalPages, Is.EqualTo(2));
            });
        }
    }
}