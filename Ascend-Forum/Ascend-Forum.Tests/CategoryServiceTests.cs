using Ascend_Forum.Core.Implementations;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Ascend_Forum.Core.Common;

namespace Ascend_Forum.Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<AscendForumDbContext> _mockContext;
        private CategoryService _service;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AscendForumDbContext>(new DbContextOptions<AscendForumDbContext>());
            _service = new CategoryService(_mockContext.Object);
        }

        [Test]
        public void GetCategoryById_ShouldReturnModel_WhenCategoryExists()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Cat 1" }
            };
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(categories);

            var result = _service.GetCategoryById(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Cat 1"));
        }

        [Test]
        public void GetDetailsById_ShouldReturnDetails_WhenCategoryExists()
        {
            var category = new Category { Id = 1, Name = "Cat 1" };
            var posts = new List<Post>
            {
                new Post { Id = 1, Title = "Post 1", CategoryId = 1, Creator = new User { AscendName = "User1" } }
            };

            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category> { category });
            _mockContext.Setup(c => c.Posts).ReturnsDbSet(posts);

            var result = _service.GetDetailsById(1);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Posts.Count(), Is.EqualTo(1));
            });
        }

        [Test]
        public void GetDetailsById_ShouldThrow_WhenCategoryDoesNotExist()
        {
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category>());

            Assert.Throws<EntityNotFoundException>(() => _service.GetDetailsById(1));
        }

        [Test]
        public void CreateCategory_ShouldAdd_WhenNameIsUnique()
        {
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category>());

            _service.CreateCategory("New", "Desc", "Url");

            _mockContext.Verify(c => c.Categories.Add(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void CreateCategory_ShouldThrow_WhenNameExists()
        {
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category> { new Category { Name = "Existing" } });

            Assert.Throws<ArgumentException>(() => _service.CreateCategory("existing", "Desc", "Url"));
        }

        [Test]
        public void EditCategory_ShouldUpdate_WhenExists()
        {
            var category = new Category { Id = 1, Name = "Old" };
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category> { category });

            _service.EditCategory(1, "New", "Desc", "Url");

            Assert.That(category.Name, Is.EqualTo("New"));
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteCategory_ShouldRemove_WhenExists()
        {
            var category = new Category { Id = 1 };
            _mockContext.Setup(c => c.Categories).ReturnsDbSet(new List<Category> { category });

            _service.DeleteCategory(1);

            _mockContext.Verify(c => c.Remove(category), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}