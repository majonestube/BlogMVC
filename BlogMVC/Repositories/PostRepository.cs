using System.Security.Principal;
using BlogMVC.Data;
using BlogMVC.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Repositories;

public class PostRepository(BlogDbContext db, UserManager<IdentityUser> userManager) : IPostRepository
{
    public IEnumerable<Post> GetPosts(int blogId)
    {
        return db.Posts.Where(p => p.BlogId == blogId).ToList();
    }

    public Post GetPost(int postId)
    {
        return db.Posts.Find( postId);
    }

    public void Create(Post post, IPrincipal principal)
    {
        db.Posts.Add(post);
        db.SaveChanges();
    }

    public void Update(Post post, IPrincipal principal)
    {
        var existingPost = db.Posts.FirstOrDefault(p => p.Id == post.Id);
        if (existingPost is null) return;
        
        existingPost.Modified = DateTime.Now;
        existingPost.Title = post.Title;
        existingPost.Content = post.Content;
        
        db.SaveChanges();
    }

    public void Delete(Post post, IPrincipal principal)
    {
        db.Posts.Remove(post);
        db.SaveChanges();
    }
    
}