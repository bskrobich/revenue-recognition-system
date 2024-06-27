using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.RequestModels;

public class RegisterRequestModel
{
    [Required]
    [MaxLength(50)] 
    public string Login { get; set; } = null!;
    
    [Required]
    [MaxLength(50)] 
    public string Password { get; set; } = null!;
    
    [Required]
    [MaxLength(50)] 
    public string Role { get; set; } = null!;
    
}