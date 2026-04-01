using Ascend_Forum.Core.Models.Member;

namespace Ascend_Forum.Core.Contracts
{
    public interface IMemberService
    {
        MemberListPageModel GetMembers(int? minPostCount = null, int? minReactionCount = null, int pageNumber = 1, int pageSize = 10);
    }
}
