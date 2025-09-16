using BlogMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BlogMVC.Controllers;

public class BlogController(IBlogRepository repository) : Controller
{
    public IActionResult Index()
    {
        var blogs = repository.GetBlogs();
        return View(blogs);
    }
    
    // GET
    [Authorize]
    public IActionResult Create()
    {
        var blog = repository.GetBlogCreateViewModel();
        return View(blog);
    }
}