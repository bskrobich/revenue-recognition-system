using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.RequestModels;

public class LoginRequestModels
{
    [Required]
    public string Login { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;

    [Required] public string Role { get; set; } = null!;

}