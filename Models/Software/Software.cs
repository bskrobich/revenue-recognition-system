using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevenueRecognitionSystem.Models.Software;

[Table("Software")]
public class Software
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("Description")]
    [MaxLength(250)]
    public string Description { get; set; }
    
    [Column("Category")]
    [MaxLength(50)]
    public string Category { get; set; }
    
    public IEnumerable<SoftwareVersion> Versions { get; set; }
    public IEnumerable<Discount> Discounts { get; set; }
}