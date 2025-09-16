using System.Security.Principal;
using BlogMVC.Data;
using BlogMVC.Models.Entities;
using BlogMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Repositories;

public class CommentRepository(BlogDbContext db, UserManager<IdentityUser> userManager) : ICommentRepository
{
    private CommentEditViewModel _commentEditViewModel;
    public IEnumerable<Comment> GetComments(int postId)
    {
        return db.Comments.Where(c => c.PostId == postId).ToList();
    }

    public Comment GetComment(int commentId)
    {
        return db.Comments.Find(commentId);
    }

    public void Create(Comment comment, IPrincipal principal)
    {
        var user = userManager.FindByNameAsync(principal.Identity.Name).Result;
        comment.Owner = user;
        db.Comments.Add(comment);
        db.SaveChanges();
    }

    public void Update(Comment comment, IPrincipal principal)
    {
        var existingComment = db.Comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existingComment is null) return;
        
        existingComment.Modified = DateTime.Now;
        existingComment.Content = comment.Content;

        db.SaveChanges();
    }

    public void Delete(Comment comment, IPrincipal principal)
    {
        db.Comments.Remove(comment);
        db.SaveChanges();
    }

    public CommentEditViewModel GetCommentCreateViewModel()
    {
        return  _commentEditViewModel;
    }
}