using System.ComponentModel.DataAnnotations;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class Category
{

    public Category()
    {
        Posts = new HashSet<Post>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryConstants.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    [MaxLength(CategoryConstants.DescriptionMaxLength)]
    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}

