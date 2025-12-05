using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class ProdottiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    // Inietta HttpClient tramite dependency injection
    public ProdottiController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("lista")]
    public async Task<IActionResult> GetProdotti()
    {
        try
        {
            // Chiama un'API esterna (esempio: JSONPlaceholder)
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var prodotti = JsonSerializer.Deserialize<List<dynamic>>(content);
                return Ok(prodotti);
            }
            
            return StatusCode((int)response.StatusCode, "Errore nella chiamata API");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Errore: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdotto(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(JsonSerializer.Deserialize<dynamic>(content));
            }
            
            return NotFound("Prodotto non trovato");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Errore: {ex.Message}");
        }
    }
}