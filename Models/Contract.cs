using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RevenueRecognitionSystem.Models.Clients;
using RevenueRecognitionSystem.Models.Software;

namespace RevenueRecognitionSystem.Models;

[Table("Contract")]
public class Contract
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("StartDate")]
    public DateTime StartDate { get; set; }
    
    [Column("EndDate")]
    public DateTime EndDate { get; set; }
    
    [Column("UpdateYears")]
    public int UpdateYears { get; set; } = 1;

    [Column("FinalPrice")] 
    public decimal FinalPrice { get; set; }
    
    [Column("IsSigned")]
    public bool IsSigned { get; set; } = false;
    
    [Column("PaidAmount")]
    public decimal PaidAmount { get; set; } = 0;
    
    [ForeignKey("SoftwareVersion")]
    [Column("SoftwareVersionId")]
    public int SoftwareVersionId { get; set; }
    
    [ForeignKey("PersonClient")]
    [Column("PersonClientId")]
    public int? PersonClientId { get; set; }
    
    [ForeignKey("CompanyClient")]
    [Column("CompanyClientId")]
    public int? CompanyClientId { get; set; }
    
    public SoftwareVersion SoftwareVersion { get; set; }
    
    public PersonClient? PersonClient { get; set; }
    
    public CompanyClient? CompanyClient { get; set; }
    
    public IEnumerable<Payment> Payments { get; set; }
}