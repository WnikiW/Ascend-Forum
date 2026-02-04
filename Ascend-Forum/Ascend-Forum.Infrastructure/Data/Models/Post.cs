using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class Post
{

    public Post()
    {
        Comments = new HashSet<Comment>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PostConstants.TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    [ForeignKey(nameof(Creator))]
    public string CreatorId { get; set; }

    public virtual User Creator { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
}
