using System.ComponentModel.DataAnnotations;

namespace Sprint_2.Entities;

public class User
{
    public long Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string Password { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string? Cellphone { get; set; }
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    [MaxLength(100)]
    public string? City { get; set; }
    
    [MaxLength(100)]
    public string? State { get; set; }
    
    [MaxLength(20)]
    public string? Zipcode { get; set; }
    
    [MaxLength(100)]
    public string? Country { get; set; }
    
    [MaxLength(20)]
    public string? Gender { get; set; }
    
    public int? Age { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}