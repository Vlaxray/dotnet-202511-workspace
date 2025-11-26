using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();
        string apiUrl = "https://italian-jokes.vercel.app/api/jokes";

        try
        {
            string jsonString = await client.GetStringAsync(apiUrl);

            // Deserializzazione JSON
            var data = JsonSerializer.Deserialize<Root>(jsonString);

            if (data != null)
            {
                Console.WriteLine($"ID: {data.id}");
                Console.WriteLine($"Joke: {data.joke}");
            }
            else
            {
                Console.WriteLine("Errore durante la deserializzazione del JSON.");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Errore nella chiamata API: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Errore nella deserializzazione del JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
    }

    public class Root
    {
        public int id { get; set; }
        public string joke { get; set; }
    }
}
