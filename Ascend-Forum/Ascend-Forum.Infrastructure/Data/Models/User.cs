using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ascend_Forum.Infrastructure.Data.Models;

public class User : IdentityUser
{
    [Required]
    [MaxLength(UserConstants.FirstNameMaxLength)]
    public string FirstName { get; set; }


    [MaxLength(UserConstants.LastNameMaxLength)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(UserConstants.AscendNameMaxLength)]
    public string AscendName { get; set; }
}
