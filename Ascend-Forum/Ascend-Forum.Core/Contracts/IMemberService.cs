using Ascend_Forum.Core.Models.Member;

namespace Ascend_Forum.Core.Contracts
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetMembers(int? minPostCount = null, int? minReactionCount = null);
    }
}
