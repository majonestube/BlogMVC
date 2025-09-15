using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Models.Entities;

public class Blog
{
    public int Id { get; set; }
    
    [MaxLength(45)]
    [Required]
    public required string Name { get; set; }
    
    [MaxLength(255)]
    public string? Description { get; set; }
    
    public string OwnerId { get; set; }
    public IdentityUser Owner { get; set; }

    public string ProfilePicture { get; set; } = "images/basic.png";
}