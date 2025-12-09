using Microsoft.AspNetCore.Mvc;
using Return_Json.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Return_Json.Controllers
{
    public class DragonBallController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private const string API_BASE_URL = "https://dragonball-api.com/api";

        public DragonBallController(ApplicationDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
public async Task<IActionResult> Search(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        return View("Index");
    }

    // 1. Cerca nel DB
    var character = await _context.DragonBallCharacters
        .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

    if (character != null)
    {
        ViewBag.Source = "Database (cached)";
        return View("Details", character);
    }

    // 2. Chiama API
    try
    {
        var response = await _httpClient.GetAsync($"{API_BASE_URL}/characters?name={name}");
        
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            
            // 🔍 DEBUG: Stampa la risposta
            Console.WriteLine("=== RISPOSTA API ===");
            Console.WriteLine(json);
            Console.WriteLine("===================");
            
            // Prova a deserializzare
            var apiResponse = JsonSerializer.Deserialize<DragonBallApiResponse>(json, new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true 
            });
            
            if (apiResponse?.Items?.Any() == true)
            {
                character = apiResponse.Items.First();
                
                // 3. Salva nel DB
                _context.DragonBallCharacters.Add(character);
                await _context.SaveChangesAsync();
                
                ViewBag.Source = "API Dragon Ball";
                return View("Details", character);
            }
            else
            {
                ViewBag.Error = $"Nessun risultato trovato. JSON ricevuto: {json.Substring(0, Math.Min(200, json.Length))}";
            }
        }
        else
        {
            ViewBag.Error = $"Errore API: {response.StatusCode}";
        }
    }
    catch (Exception ex)
    {
        ViewBag.Error = $"Errore: {ex.Message}";
    }

    return View("Index");
}
    }}