using Ascend_Forum.Core.Common;
using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ganss.Xss;

namespace Ascend_Forum.Core.Implementations
{
    public class CommentService(AscendForumDbContext context, IHtmlSanitizer sanitizer) : ICommentService
    {
        public void CreateComment(string content, int postId, string creatorId, int? parentId)
        {

            var postExists = context.Posts.Any(x => x.Id == postId);

            if (!postExists)
                throw new EntityNotFoundException(postId, nameof(Post));

            if (parentId != null)
            {
                var parentComment = context.Comments
                    .FirstOrDefault(x => x.Id == parentId);

                if (parentComment == null)
                    throw new EntityNotFoundException(parentId.Value, nameof(Comment));

                if (parentComment.PostId != postId)
                    throw new ArgumentException("Invalid parent comment for this post.");
            }


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
