using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevenueRecognitionSystem.Models;

[Table("User")]
public class User
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Login")]
    [MaxLength(50)]
    public string Login { get; set; }
    
    [Column("Password")]
    [MaxLength(50)]
    public string Password { get; set; }
    
    [Column("Role")]
    [MaxLength(50)]
    public string Role { get; set; }
}