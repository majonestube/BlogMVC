using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Models.ViewModels;

public class PostEditViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(45)]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; }
    
}