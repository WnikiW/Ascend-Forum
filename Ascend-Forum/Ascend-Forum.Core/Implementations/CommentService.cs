using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ganss.Xss;

namespace Ascend_Forum.Core.Implementations
{
    public class CommentService(AscendForumDbContext context) : ICommentService
    {
        public void CreateComment(string content, int postId, string creatorId, int? parentId)
        {
            var sanitizer = new HtmlSanitizer();

            var comment = new Comment
            {
                Content = sanitizer.Sanitize(content),
                CreatedOn = DateTime.Now,
                CreatorId = creatorId,
                ParentId = parentId,
                PostId = postId,
            };

            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
