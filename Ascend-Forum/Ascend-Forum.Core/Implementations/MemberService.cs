using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Core.Models.Member;
using Ascend_Forum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Core.Implementations
{
    public class MemberService(AscendForumDbContext context) : IMemberService
    {
        public MemberListPageModel GetMembers(int? minPostCount = null, int? minReactionCount = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = context.Users.AsQueryable();

            if (minPostCount != null)
            {
                query = query.Where(u => u.Posts.Count >= minPostCount);
            }

            if (minReactionCount != null)
            {
                query = query.Where(u => u.Comments.Sum(c => c.Reactions.Count) >= minReactionCount);
            }

            int totalMembers = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalMembers / pageSize);

            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages && totalPages > 0) pageNumber = totalPages;

            var members = query
                .Select(u => new MemberViewModel
                {
                    AscendName = u.AscendName,
                    PostCount = u.Posts.Count,
                    CommentReactionCount = u.Comments.Sum(c => c.Reactions.Count)
                })
                .OrderByDescending(m => m.PostCount)
                .ThenBy(m => m.AscendName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new MemberListPageModel
            {
                Members = members,
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                MinPostCount = minPostCount,
                MinReactionCount = minReactionCount
            };
        }
    }
}
