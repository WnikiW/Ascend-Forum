using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Infrastructure.Data;

public class AscendForumDbContext : IdentityDbContext<User>
{
    public AscendForumDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(u => u.AscendName)
            .IsUnique();

        base.OnModelCreating(builder);
    }
}