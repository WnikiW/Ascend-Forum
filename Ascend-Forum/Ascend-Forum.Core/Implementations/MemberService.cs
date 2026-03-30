using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Core.Models.Member;
using Ascend_Forum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Core.Implementations
{
    public class MemberService(AscendForumDbContext context) : IMemberService
    {
        public IEnumerable<MemberViewModel> GetMembers()
        {
            return context.Users
                .Select(u => new MemberViewModel
                {
                    AscendName = u.AscendName,
                    PostCount = u.Posts.Count,
                    CommentReactionCount = u.Comments.Sum(c => c.Reactions.Count)
                })
                .OrderByDescending(m => m.PostCount)
                .ThenBy(m => m.AscendName)
                .ToList();
        }
    }
}
