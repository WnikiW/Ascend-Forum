using Ascend_Forum.Infrastructure.Data.Enums;

namespace Ascend_Forum.ViewModels
{
    public class CommentModel
    {
        public CommentModel()
        {
            Replies = new List<CommentModel>();
            ReactionCounts = new Dictionary<ReactionType, int>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public CommentModel? Parent { get; set; }
        public string? CreatorUsername { get; set; }
        public string CreatedOn { get; set; }
        public List<CommentModel> Replies { get; set; }
        public Dictionary<ReactionType, int> ReactionCounts { get; set; }
        public ReactionType? CurrentUserReaction { get; set; }
    }
}
