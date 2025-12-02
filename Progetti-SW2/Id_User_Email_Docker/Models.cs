using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Credenziale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(135)]
    public string Email { get; set; }
    public Credenziale() : this(123, "marios", "mario@gmail..com") { }

    public Credenziale(int ID, string Username, string Email)
    {
        this.Username = Username;
        this.Email = Email;
    }
}