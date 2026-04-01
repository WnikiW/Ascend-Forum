namespace Ascend_Forum.Core.Models.Member
{
    public class MemberListPageModel
    {
        public IEnumerable<MemberViewModel> Members { get; set; } = new List<MemberViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int? MinPostCount { get; set; }
        public int? MinReactionCount { get; set; }
    }
}
