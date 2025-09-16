using System.Security.Principal;
using BlogMVC.Models.Entities;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Repositories;

public interface IPostRepository
{
    IEnumerable<Post> GetPosts(int blogId);
    
    void Create(Post post, IPrincipal principal);
    
    Post GetPost(int postId);
    
    void Update(Post post, IPrincipal principal);
    
    void Delete(Post post, IPrincipal principal);
    
    int GetNumberOfComments(int postId);
    
    PostEditViewModel GetPostCreateViewModel();
}