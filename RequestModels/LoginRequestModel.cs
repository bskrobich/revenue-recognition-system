using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.RequestModels;

public class LoginRequestModel
{
    [Required]
    public string Login { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}