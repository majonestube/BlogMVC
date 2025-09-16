using System.Security.Principal;
using BlogMVC.Models.Entities;

namespace BlogMVC.Repositories;

public interface ICommentRepository
{
    IEnumerable<Comment> GetComments(int postId);
    
    void Create(Comment comment, IPrincipal principal);
    
    Comment GetComment(int commentId);
    
    void Update(Comment comment, IPrincipal principal);
    
    void Delete(Comment comment, IPrincipal principal);
    
    //TODO CommentEditViewModel
}