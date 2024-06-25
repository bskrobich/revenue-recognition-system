using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RevenueRecognitionSystem.Models.Software;

[Table("Discount")]
public class Discount
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("PercentageValue")]
    public decimal PercentageValue { get; set; }
    
    [Column("StartDate")]
    public DateTime StartDate { get; set; }
    
    [Column("EndDate")]
    public DateTime EndDate { get; set; }
    
    [ForeignKey("Software")]
    public int SoftwareId { get; set; }
    
    public Software Software { get; set; }
}