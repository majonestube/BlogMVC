using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Models.ViewModels;

public class CommentEditViewModel
{
    public int Id { get; set; }
    
    [Required]
    public string Content { get; set; }
}