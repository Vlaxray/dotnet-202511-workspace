using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Chiedere un numero tra 1 e 5
        int numero;
        int g = 0;
        do
        {
            Console.Write("Inserisci un numero tra 1 e 5: ");
        } while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 5);

        Console.WriteLine($"Richiesti {numero} facts.");

        // Chiamata API
        using HttpClient client = new HttpClient();

        {
            while (g < 5)
            {
                string apiUrl = $"https://dogapi.dog/api/facts?number={numero}";

                try
                {
                    string jsonString = await client.GetStringAsync(apiUrl);

                    // Deserializzazione JSON
                    var data = JsonSerializer.Deserialize<Root>(jsonString);

                    if (data != null && data.facts != null && data.facts.Count > 0)
                    {
                        Console.WriteLine("Ecco i {numero} Facts richiesti:");
                        foreach (var fact in data.facts)
                        {
                            Console.WriteLine($"- {fact}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessun fact disponibile dall'API.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore nella chiamata API: {ex.Message}");
                }
                g++;
            }

        }
    }
    public class Root
    {
        public List<string> facts { get; set; }
    }
}
