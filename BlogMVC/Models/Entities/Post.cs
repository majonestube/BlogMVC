using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Models.Entities;

public class Post
{
    public int Id { get; set; }
    
    [MaxLength(45)]
    [Required]
    public required string Title { get; set; }
    
    [Required]
    public required string Content { get; set; }
    
    public DateTime Created { get; set; } = DateTime.Now;
    
    public DateTime Modified { get; set; } = DateTime.Now;
    
    public int BlogId { get; set; }
}