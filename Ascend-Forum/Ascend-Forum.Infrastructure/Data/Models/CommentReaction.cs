using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ascend_Forum.Infrastructure.Data.Enums;

namespace Ascend_Forum.Infrastructure.Data.Models
{
    public class CommentReaction
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public ReactionType ReactionType { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
