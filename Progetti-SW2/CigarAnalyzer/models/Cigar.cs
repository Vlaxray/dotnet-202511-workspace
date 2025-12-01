using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CigarAnalyzer.Models
{
    public class Cigar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string PackageInfo { get; set; } = string.Empty;
        
        public int PiecesPerPackage { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerKg { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PackagePrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerPiece { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValueScore { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class AnalysisResult
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime AnalysisDate { get; set; } = DateTime.UtcNow;
        
        public int TotalCigars { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal AveragePricePerPiece { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinPricePerPiece { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxPricePerPiece { get; set; }
        
        // Navigation property
        public List<Cigar> Cigars { get; set; } = new List<Cigar>();
    }
}