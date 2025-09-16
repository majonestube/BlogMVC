using BlogMVC.Authorization;
using BlogMVC.Models.Entities;
using BlogMVC.Models.ViewModels;
using BlogMVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers;

public class PostController(IPostRepository repository, IAuthorizationService authorizationService) : Controller
{
    public async Task<IActionResult> Index(int blogId, string name)
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
        
        // Check if the user is the blog owner
        var blog = repository.GetBlog(blogId);
        ViewBag.CanCreatePost = false;
        if (User.Identity?.IsAuthenticated == true && blog != null)
        {
            var authResult = await authorizationService.AuthorizeAsync(User, blog, new OwnerRequirement());
            ViewBag.CanCreatePost = authResult.Succeeded;
        }
        
        return View(posts);
    }
    
    // GET
    [Authorize]
    public async Task<IActionResult> Create(int blogId)
    {
        var blog = repository.GetBlog(blogId);
        if (blog == null)
        {
            return NotFound();
        }
        
        // Check ownership
        var authResult = await authorizationService.AuthorizeAsync(User, blog, new OwnerRequirement());
        if (!authResult.Succeeded)
        {
            return Forbid();
        }
        
        var post = repository.GetPostCreateViewModel();
        return View(post);
    }
    
    // POST
    [HttpPost]
    [Authorize]
    public IActionResult Create([Bind("Title, Content")] PostEditViewModel post)
    {
        try
        {
            if (!ModelState.IsValid) return View(post);

            var b = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
            };

            repository.Create(b, User);
            
            // TODO TempData
            return RedirectToAction("Index");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // TODO TempData
            return RedirectToAction("Index");
        }
    }
    
}