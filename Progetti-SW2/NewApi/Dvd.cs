using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Dvd
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Titolo { get; set; } 

    [Required]
    [MaxLength(100)]
    public string Genere { get; set; } 

    public Dvd(string titolo , string genere)
    {
        this.Titolo = titolo;
        this.Genere = genere;
    }

    public Dvd():this("dvd generico" ,"avventura")
    {
        
    }
}