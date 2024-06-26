using System.ComponentModel.DataAnnotations;
using RevenueRecognitionSystem.Validations;

namespace RevenueRecognitionSystem.RequestModels;

public class PaymentRequestModel
{
    [RequiredIf(nameof(CompanyClientId), null, ErrorMessage = "Either PersonClientId or CompanyClientId must be provided.")]
    public int? PersonClientId { get; set; }
    
    [RequiredIf(nameof(PersonClientId), null, ErrorMessage = "Either PersonClientId or CompanyClientId must be provided.")]
    public int? CompanyClientId { get; set; }
    
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Payment date is required.")]
    [DataType(DataType.Date)]
    public DateTime PaymentDate { get; set; }
    
}