using System.Security.Principal;
using BlogMVC.Models.Entities;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Repositories;

public interface IBlogRepository
{
    IEnumerable<Blog> GetBlogs();
    
    Blog? GetBlog(int id);
    void Create(Blog blog, IPrincipal principal);
    
    BlogEditViewModel GetBlogCreateViewModel();
}