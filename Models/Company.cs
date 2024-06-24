using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevenueRecognitionSystem.Models;

[Table("Company")]
public class Company
{
    [Key]
    [Column("KRS")]
    [MaxLength(14)]
    public string KRS { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("Address")]
    [MaxLength(200)]
    public string Address { get; set; }
    
    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Column("PhoneNumber")]
    [MaxLength(9)]
    public string PhoneNumber { get; set; }
}
    