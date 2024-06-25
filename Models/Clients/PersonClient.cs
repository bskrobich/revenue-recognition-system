using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevenueRecognitionSystem.Models.Clients;

[Table("Person")]
public class PersonClient
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("FirstName")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Column("Address")]
    [MaxLength(200)]
    public string Address { get; set; }
    
    [Column("Email")]
    [MaxLength(100)]
    public string Email { get; set; }
    
    [Column("PhoneNumber")]
    [MaxLength(9)]
    public string PhoneNumber { get; set; }
    
    [Column("PESEL")]
    [MaxLength(11)]
    public string PESEL { get; set; }

    [Column("IsDeleted")] 
    public bool IsDeleted { get; set; }

    private IEnumerable<Contract> Contracts { get; set; }
    
    public IEnumerable<Payment> Payments { get; set; }
}