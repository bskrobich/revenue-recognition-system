using System.ComponentModel.DataAnnotations;
using RevenueRecognitionSystem.Validations;

namespace RevenueRecognitionSystem.RequestModels;

public class CreateContractRequestModel
{
    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    [DataType(DataType.Date)]
    [DateRange(nameof(StartDate), 3, 30, ErrorMessage = "The date range between StartDate and EndDate must be between 3 and 30 days.")]
    public DateTime EndDate { get; set; }

    [Range(1, 3, ErrorMessage = "Update years must be between 1 and 3.")]
    public int UpdateYears { get; set; } = 1;

    [Required(ErrorMessage = "Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Software ID is required.")]
    public int SoftwareId { get; set; }

    [Required(ErrorMessage = "Software version ID is required.")]
    public int SoftwareVersionId { get; set; }

    [RequiredIf(nameof(CompanyClientId), null, ErrorMessage = "Either PersonClientId or CompanyClientId must be provided.")]
    public int? PersonClientId { get; set; }

    [RequiredIf(nameof(PersonClientId), null, ErrorMessage = "Either PersonClientId or CompanyClientId must be provided.")]
    public int? CompanyClientId { get; set; }
}