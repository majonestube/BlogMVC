using System.Security.Principal;
using BlogMVC.Models.Entities;

namespace BlogMVC.Repositories;

public interface IBlogRepository
{
    IEnumerable<Blog> GetBlogs();
    
    Blog? GetBlog(int id);
    void Create(Blog blog, IPrincipal principal);
    // TODO BlogEditViewModel
}