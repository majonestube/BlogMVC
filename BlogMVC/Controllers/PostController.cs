using BlogMVC.Models.ViewModels;
using BlogMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers;

public class PostController(IPostRepository repository) : Controller
{
    public IActionResult Index(int blogId, string name)
    {
        var posts = repository.GetPosts(blogId)
            .Select(p => new PostsViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Created = p.Created,
                Modified = p.Modified,
                CommentCount = repository.GetNumberOfComments(p.Id)
            }).ToList();
        ViewBag.Title = name;
        
        return View(posts);
    }
    
    // GET
    [Authorize]
    public IActionResult Create()
    {
        var post = repository.GetPostCreateViewModel();
        return View(post);
    }
}