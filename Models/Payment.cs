using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RevenueRecognitionSystem.Models.Clients;

namespace RevenueRecognitionSystem.Models;

[Table("Payment")]
public class Payment
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [ForeignKey("PersonClient")]
    [Column("PersonClientId")]
    public int? PersonClientId { get; set; }
    
    [ForeignKey("CompanyClient")]
    [Column("CompanyClientId")]
    public int? CompanyClientId { get; set; }
    
    [ForeignKey("Contract")]
    [Column("ContractId")]
    public int ContractId { get; set; }
    
    [Column("PaymentDate")]
    public DateTime PaymentDate { get; set; }
    
    public PersonClient? PersonClient { get; set; }
    public CompanyClient? CompanyClient { get; set; }
    public Contract Contract { get; set; }
    
}