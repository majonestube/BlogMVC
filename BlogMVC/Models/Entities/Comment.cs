using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Models.Entities;

public class Comment
{
    public int Id { get; set; }
    
    [Required]
    public required string Content { get; set; }
    
    public DateTime Created { get; set; } = DateTime.Now;
    
    public DateTime Modified { get; set; } =  DateTime.Now;
    
    public int PostId { get; set; }
    
    public string OwnerId { get; set; }
    public IdentityUser Owner { get; set; }
}