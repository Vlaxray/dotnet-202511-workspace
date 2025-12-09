using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class PochoCharacter
{
    public int Id { get; set; }              // chiave primaria DB, NON l'id API
    public int CharacterId { get; set; }     // id reale del personaggio Dragon Ball
    public string Name { get; set; }
    public string Race { get; set; }
    public string Gender { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Affiliation { get; set; }
}
