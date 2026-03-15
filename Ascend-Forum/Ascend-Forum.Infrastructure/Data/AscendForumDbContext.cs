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

        builder.Entity<CommentReaction>(entity =>
        {
            entity.HasKey(cr => cr.Id);

            entity.HasOne(cr => cr.Comment)
                .WithMany(c => c.Reactions)
                .HasForeignKey(cr => cr.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(cr => cr.User)
                .WithMany(u => u.CommentReactions)
                .HasForeignKey(cr => cr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(cr => new { cr.CommentId, cr.UserId })
                .IsUnique();
        });

        base.OnModelCreating(builder);
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<CommentReaction> CommentReactions { get; set; }
}
