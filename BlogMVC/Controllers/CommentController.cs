using BlogMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers;

public class CommentController(ICommentRepository repository) : Controller
{
    public IActionResult Index(int postId, string title)
    {
        var comments = repository.GetComments(postId).ToList();

        ViewBag.Title = title;
        
        return View(comments);
    }
}