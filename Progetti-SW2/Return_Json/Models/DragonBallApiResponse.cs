using System.Text.Json.Serialization;

namespace Return_Json.Models
{
    // Classe per deserializzare la risposta dell'API
    public class DragonBallApiResponse
    {
        [JsonPropertyName("items")]
        public List<DragonBallCharacter> Items { get; set; }
        
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
        
        [JsonPropertyName("links")]
        public Links Links { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }
        
        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; }
        
        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }
        
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
        
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("first")]
        public string First { get; set; }
        
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        
        [JsonPropertyName("next")]
        public string Next { get; set; }
        
        [JsonPropertyName("last")]
        public string Last { get; set; }
    }

    // Modello principale del personaggio
    public class DragonBallCharacter
    {
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("ki")]
        public string Ki { get; set; }
        
        [JsonPropertyName("maxKi")]
        public string MaxKi { get; set; }
        
        [JsonPropertyName("race")]
        public string Race { get; set; }
        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("image")]
        public string Image { get; set; }
        
        [JsonPropertyName("affiliation")]
        public string Affiliation { get; set; }
    }
}