using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AscendForumDbContext : IdentityDbContext<User>
{
    public AscendForumDbContext(DbContextOptions options) : base(options)
    {
    }
}