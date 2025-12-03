using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("AppDB")]
public class Output_Pocho
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Symbol { get; set; }

    [MaxLength(100)]
    public string Sector { get; set; }

    [MaxLength(100)]
    public string Industry { get; set; }

    [MaxLength(200)]
    public string Location { get; set; }

    public int Employees { get; set; }

    [MaxLength(500)]
    public string Website { get; set; }

    [Column(TypeName = "text")]
    public string LongBusinessSummary { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

   
}