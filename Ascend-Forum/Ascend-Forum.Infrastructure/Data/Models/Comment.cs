using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class Comment
{

    public Comment()
    {
        Reactions = new HashSet<CommentReaction>();
    }

    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Creator))]
    public string CreatorId { get; set; }

    public virtual User Creator { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }

    public virtual Post Post { get; set; }

    [ForeignKey(nameof(Parent))]
    public int? ParentId { get; set; }

    public virtual Comment Parent { get; set; }

    public virtual ICollection<CommentReaction> Reactions { get; set; }
}