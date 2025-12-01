using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Autore
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Cognome { get; set; } = string.Empty;

    public DateTime? DataNascita { get; set; }
    
    [MaxLength(50)]
    public string? Nazionalita { get; set; }
    
    [MaxLength(150)]
    public string? Email { get; set; }

    public DateTime DataCreazione { get; set; }
    public DateTime DataModifica { get; set; }

    // Navigazione
    public virtual ICollection<Libro> Libri { get; set; } = new List<Libro>();

    [NotMapped]
    public string NomeCompleto => $"{Nome} {Cognome}";
}

public class Libro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titolo { get; set; } = string.Empty;

    [Required]
    [MaxLength(13)]
    public string ISBN { get; set; } = string.Empty;

    public int? AnnoPubblicazione { get; set; }
    
    [MaxLength(50)]
    public string? Genere { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Prezzo { get; set; }

    public int QuantitaDisponibile { get; set; }

    public int? AutoreId { get; set; }

    public DateTime DataCreazione { get; set; }
    public DateTime DataModifica { get; set; }

    // Navigazione
    [ForeignKey("AutoreId")]
    public virtual Autore? Autore { get; set; }
}