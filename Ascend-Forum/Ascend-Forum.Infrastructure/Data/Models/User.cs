using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class User : IdentityUser
{
    public User()
    {
        Posts = new HashSet<Post>();
        Comments = new HashSet<Comment>();
    }

    [Required]
    [MaxLength(UserConstants.FirstNameMaxLength)]
    public string FirstName { get; set; }


    [MaxLength(UserConstants.LastNameMaxLength)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(UserConstants.AscendNameMaxLength)]
    public string AscendName { get; set; }

    public virtual ICollection<Post> Posts { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
}
