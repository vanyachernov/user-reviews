using System.ComponentModel.DataAnnotations;

namespace Reviews.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    [RegularExpression("^[A-Za-z0-9]{3,100}$", ErrorMessage = "Only Latin letters and digits, 3-100 chars")]
    public string UserName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Url]
    public string? Homepage { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Comment> Comments { get; set; } = [];
}