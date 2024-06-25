using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.RequestModels;

public class UpdatePersonClientRequestModel
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone number must be 9 characters long.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must contain only digits.")]
    public string PhoneNumber { get; set; }
}