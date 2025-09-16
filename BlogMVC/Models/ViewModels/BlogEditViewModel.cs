using System.ComponentModel.DataAnnotations;

namespace BlogMVC.Models.ViewModels;

public class BlogEditViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title Required")]
    [StringLength(45)]
    public string Title { get; set; }
    
    [StringLength(255)]
    public string? Description { get; set; }

    public List<string> ProfilePictures { get; set; } = [];
}