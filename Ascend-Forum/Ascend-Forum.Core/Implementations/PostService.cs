using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Core.Models.Post;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Enums;
using Ascend_Forum.Infrastructure.Data.Models;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Ascend_Forum.Core.Implementations
{
    public class PostService(AscendForumDbContext context) : IPostService
    {
        public int CreatePost(string title, string content, int categoryId, string creatorId)
        {
            var dbCategory = context.Categories
                .FirstOrDefault(x => x.Id == categoryId);

            if (dbCategory == null)
                throw new ArgumentException("Category does not exist.");

            var sanitizer = new HtmlSanitizer();

            var dbPost = new Post
            {
                Title = title,
                Content = sanitizer.Sanitize(content),
                CreatorId = creatorId,
                CategoryId = dbCategory.Id,
                CreatedOn = DateTime.Now,
            };

            context.Posts.Add(dbPost);
            context.SaveChanges();

            return dbPost.Id;
        }

        public PostDetailsServiceModel GetPostDetails(int postId, string? userId)
        {
            var dbPost = context.Posts
                .Include(x => x.Creator)
                .FirstOrDefault(x => x.Id == postId);

            if (dbPost == null)
                throw new ArgumentException("Post does not exist.");

            var dbComments = context.Comments
                .Include(x => x.Creator)
                .Where(x => x.PostId == dbPost.Id)
                .ToList();

            var commentIds = dbComments
                .Select(x => x.Id)
                .ToList();

            var reactions = context.CommentReactions
                .Where(x => commentIds.Contains(x.CommentId))
                .ToList();

            var comments = dbComments
                .Select(x =>
                {
                    var commentReactions = reactions
                        .Where(r => r.CommentId == x.Id)
                        .ToList();

                    return new CommentServiceModel
                    {
                        Id = x.Id,
                        CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                        Content = x.Content,
                        CreatorUsername = x.Creator.UserName,
                        ParentId = x.ParentId,
                        ReactionCounts = commentReactions
                            .GroupBy(r => r.ReactionType)
                            .ToDictionary(g => g.Key, g => g.Count()),
                        CurrentUserReaction = commentReactions
                            .Where(r => r.UserId == userId)
                            .Select(r => (ReactionType?)r.ReactionType)
                            .FirstOrDefault()
                    };
                })
                .ToList();

            var projectedComments = comments
                .Select(x => new CommentServiceModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Content = x.Content,
                    CreatorUsername = x.CreatorUsername,
                    ParentId = x.ParentId,
                    Parent = comments.FirstOrDefault(y => y.Id == x.ParentId),
                    ReactionCounts = x.ReactionCounts,
                    CurrentUserReaction = x.CurrentUserReaction
                })
                .ToArray();

            return new PostDetailsServiceModel
            {
                Id = dbPost.Id,
                Title = dbPost.Title,
                Content = dbPost.Content,
                CreatorUsername = dbPost.Creator.AscendName,
                CreatedOn = dbPost.CreatedOn.ToString(CultureInfo.InvariantCulture),
                Comments = projectedComments,
            };
        }
    }
}
