using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevenueRecognitionSystem.Models.Software;

[Table("Software_Version")]
public class SoftwareVersion
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Version")]
    public decimal Version { get; set; }
    
    [ForeignKey("Software")]
    [Column("SoftwareId")]
    public int SoftwareId { get; set; }

    public Software Software { get; set; }
    
    public IEnumerable<Contract> Contracts { get; set; }
}