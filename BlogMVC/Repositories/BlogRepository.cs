using System.Security.Principal;
using BlogMVC.Data;
using BlogMVC.Models.Entities;
using BlogMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repositories;

public class BlogRepository(BlogDbContext db, UserManager<IdentityUser> userManager) : IBlogRepository
{
    private BlogEditViewModel _viewModel;
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

    public Blog? GetBlog(int id)
    {
        return db.Blogs.Find(id);
    }

    public void Create(Blog blog, IPrincipal principal)
    {
        var user = userManager.FindByNameAsync(principal.Identity.Name).Result;
        blog.Owner = user;
        db.Blogs.Add(blog);
        db.SaveChanges();
    }

    public BlogEditViewModel GetBlogCreateViewModel()
    {
        var profilePictures = Directory.GetFiles("wwwroot/images")
            .Select(Path.GetFileName)
            .ToList();
        _viewModel = new BlogEditViewModel()
        {
            ProfilePictures = profilePictures,
        };

        return _viewModel;
    }
}
