using Ascend_Forum.Infrastructure.Data.Enums;
using System.Collections.Generic;

namespace Ascend_Forum.Core.Models.Post
{
    public class CommentServiceModel
    {
        public CommentServiceModel()
        {
            Replies = new List<CommentServiceModel>();
            ReactionCounts = new Dictionary<ReactionType, int>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public CommentServiceModel? Parent { get; set; }
        public string? CreatorUsername { get; set; }
        public string CreatedOn { get; set; }
        public List<CommentServiceModel> Replies { get; set; }
        public Dictionary<ReactionType, int> ReactionCounts { get; set; }
        public ReactionType? CurrentUserReaction { get; set; }
    }
}
