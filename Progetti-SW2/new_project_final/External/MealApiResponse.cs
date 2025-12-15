using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace new_project_final.External
{
    public class MealApiResponse
    {
        [JsonPropertyName("meals")]
        public List<MealApiItem> Meals { get; set; }
    }

    public class MealApiItem
    {
        [JsonPropertyName("idMeal")]
        public string IdMeal { get; set; }

        [JsonPropertyName("strMeal")]
        public string StrMeal { get; set; }

        [JsonPropertyName("strCategory")]
        public string StrCategory { get; set; }

        [JsonPropertyName("strArea")]
        public string StrArea { get; set; }

        [JsonPropertyName("strInstructions")]
        public string StrInstructions { get; set; }

        [JsonPropertyName("strMealThumb")]
        public string StrMealThumb { get; set; }
    }
}
