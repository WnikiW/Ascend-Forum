using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class User : IdentityUser
{
    [MaxLength(UserConstants.FirstNameMaxLength)]

    public string FirstName { get; set; }


    [MaxLength(UserConstants.LastNameMaxLength)]
    public string LastName { get; set; }
}