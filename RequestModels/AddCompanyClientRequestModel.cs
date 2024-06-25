using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionSystem.RequestModels;

public class AddCompanyClientRequestModel
{
    [Required(ErrorMessage = "KRS is required.")]
    [StringLength(14, MinimumLength = 9, ErrorMessage = "KRS must between 9-14 characters long.")]
    [RegularExpression(@"^\d{9,14}$", ErrorMessage = "KRS must contain only digits.")]
    public string KRS { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone number must be 9 characters long.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must contain only digits.")]
    public string PhoneNumber { get; set; }
}