using System.Security.Principal;
using BlogMVC.Data;
using BlogMVC.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repositories;

public class BlogRepository(BlogDbContext db, UserManager<IdentityUser> userManager) : IBlogRepository
{
    public IEnumerable<Blog> GetBlogs()
    {
        try
        {
            var blogs = db.Blogs
                .Include(b => b.Owner).ToList();
            
            return blogs;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            
            return new List<Blog>();
        }
    }

    public void Save(Blog blog, IPrincipal principal)
    {
        var user = userManager.FindByNameAsync(principal.Identity.Name).Result;
        blog.Owner = user;
        db.Blogs.Add(blog);
        db.SaveChanges();
    }
    
    // TODO add viewmodel
}
