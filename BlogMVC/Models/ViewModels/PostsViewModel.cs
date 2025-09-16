namespace BlogMVC.Models.ViewModels;

public class PostsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public int BlogId { get; set; }
    public int CommentCount { get; set; }
}