using BlogMVC.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Blog>().ToTable("Blog");
        
        // SEEDING PREPARATION
        var hasher = new PasswordHasher<IdentityUser>();
        var defaultUser = new IdentityUser
        {
            Id = "default-id",
            UserName = "default@example.com",
            NormalizedUserName = "DEFAULT_USER",
            Email = "default@example.com",
            NormalizedEmail = "DEFAULT@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "DefaultPassword123!"),
            SecurityStamp = string.Empty,
        };
        
        var donkeyUser = new IdentityUser
        {
            Id = "donkey-id",
            UserName = "donkey@example.com",
            NormalizedUserName = "THEDONKEY",
            Email = "donkey@example.com",
            NormalizedEmail = "DONKEY@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "DonkeyKong!"),
            SecurityStamp = string.Empty,
        };
        
        // SEEDING
        builder.Entity<IdentityUser>().HasData(defaultUser);
        builder.Entity<IdentityUser>().HasData(donkeyUser);
        
        // Blog
        builder.Entity<Blog>().HasData(new Blog
        {
            Id = 1,
            Name = "A day in the life of a mermaid",
            Description = "Have you ever wondered what it's like to be a mermaid? Well here's your chance to find out...",
            OwnerId = defaultUser.Id,
            ProfilePicture = "images/duck.png"
        });
        
        // Posts for mermaid blog
        builder.Entity<Post>().HasData(new Post
        {
            Id = 1,
            BlogId = 1,
            Title = "A new school",
            Content =
                "Today I started at my new school. My parents told me it would be full of fairytale creatures, but it was mainly just the bad ones. Like wolves and step-parents.",
            Created = new DateTime(2025, 8, 20, 19, 15, 0),
        });
        builder.Entity<Post>().HasData(new Post
        {
            Id = 2,
            BlogId = 1,
            Title = "Made some new friends",
            Content =
                "Turns out there are more creatures here, they were just scared initially. I started talking to a nice donkey today. He was a bit too talkative for my taste, but that's OK.",
            Created = new DateTime(2025, 9, 1, 16, 33, 25),
        });
        builder.Entity<Post>().HasData(new Post
        {
            Id = 3,
            BlogId = 1,
            Title = "Prom?",
            Content =
                "I'm wondering if I should ask the donkey to prom... What do you think?",
            Created = new DateTime(2025, 9, 15, 19, 19, 46),
        });
        
        // Comments for the mermaid blog
        builder.Entity<Comment>().HasData(new Comment
        {
            Id = 1,
            PostId = 2,
            Content = "He sounds lovely!",
            Created = new DateTime(2025, 9, 16, 12, 59, 25),
            OwnerId = donkeyUser.Id,
        });
        
        builder.Entity<Comment>().HasData(new Comment
        {
            Id = 2,
            PostId = 3,
            Content = "I think he has a girlfriend... Who also might be a dragon, so watch out.",
            Created = new DateTime(2025, 9, 16, 13, 02, 03),
            OwnerId = donkeyUser.Id,
        });
        
        builder.Entity<Comment>().HasData(new Comment
        {
            Id = 3,
            PostId = 3,
            Content = "Jeez, never mind",
            Created = new DateTime(2025, 9, 16, 13, 14, 16),
            OwnerId = defaultUser.Id,
        });
    }
    
    public DbSet<IdentityUser>? Users { get; set; }
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }
    public DbSet<Comment>? Comments { get; set; }
}