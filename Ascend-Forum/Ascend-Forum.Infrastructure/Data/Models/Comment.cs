using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Creator))]
    public string CreatorId { get; set; }

    public User Creator { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }

    public virtual Post Post { get; set; }

    [ForeignKey(nameof(Parent))]
    public int? ParentId { get; set; }

    public Comment Parent { get; set; }
}