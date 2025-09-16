using System.Security.Principal;
using BlogMVC.Models.Entities;

namespace BlogMVC.Repositories;

public interface IBlogRepository
{
    IEnumerable<Blog> GetBlogs();
    void Save(Blog blog, IPrincipal principal);
    // TODO BlogEditViewModel
}