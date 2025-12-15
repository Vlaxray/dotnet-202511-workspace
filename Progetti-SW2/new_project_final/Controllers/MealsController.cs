using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using new_project_final.Models;
using new_project_final.Dtos;
using new_project_final.External;
using new_project_final.Data;


[ApiController]
[Route("api/meals")]
public class MealsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly HttpClient _http;

    public MealsController(AppDbContext db, HttpClient http)
    {
        _db = db;
        _http = http;
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search(MealSearchRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Query))
            return BadRequest("Query vuota");

        // ✅ QUI — normalizzazione input
        var query = request.Query.Trim().ToLowerInvariant();

        // 1️⃣ Cerca nel DB
        var cached = await _db.Meals
            .FirstOrDefaultAsync(m => m.Name.ToLower().Contains(query));

        if (cached != null)
        {
            return Ok(new MealDto(
                cached.ExternalId,
                cached.Name,
                cached.Category,
                cached.Area,
                cached.Instructions,
                cached.Thumbnail
            ));
        }

        // 2️⃣ Chiamata API esterna
        var apiResponse = await _http.GetFromJsonAsync<MealApiResponse>(
            $"https://www.themealdb.com/api/json/v1/1/search.php?s={query}"
        );

        var mealApi = apiResponse?.Meals?.FirstOrDefault();
        if (mealApi == null)
            return NotFound("Nessun risultato");

        // 3️⃣ Salvataggio DB
        var meal = new Meal
        {
            ExternalId = mealApi.IdMeal,
            Name = mealApi.StrMeal,
            Category = mealApi.StrCategory,
            Area = mealApi.StrArea,
            Instructions = mealApi.StrInstructions,
            Thumbnail = mealApi.StrMealThumb
        };

        _db.Meals.Add(meal);
        await _db.SaveChangesAsync();

        return Ok(new MealDto(
            meal.ExternalId,
            meal.Name,
            meal.Category,
            meal.Area,
            meal.Instructions,
            meal.Thumbnail
        ));
    }

    [HttpGet("suggest")]
    public async Task<IActionResult> Suggest([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q) || q.Length < 1)
            return Ok(Array.Empty<string>());

        q = q.Trim().ToLowerInvariant();

        // 1️⃣ TENTATIVO: DATABASE
        var dbResults = await _db.Meals
            .Where(m => m.Name.ToLower().StartsWith(q))
            .OrderBy(m => m.Name)
            .Select(m => m.Name)
            .Take(10)
            .ToListAsync();

        if (dbResults.Count > 0)
        {
            Console.WriteLine($"[SUGGEST][DB HIT] '{q}'");
            return Ok(dbResults);
        }

        Console.WriteLine($"[SUGGEST][DB MISS] '{q}' → API");

        // 2️⃣ FALLBACK: API ESTERNA
        var apiResponse = await _http.GetFromJsonAsync<MealApiResponse>(
            $"https://www.themealdb.com/api/json/v1/1/search.php?s={q}"
        );

        if (apiResponse?.Meals == null)
            return Ok(Array.Empty<string>());

        var names = new List<string>();

        foreach (var mealApi in apiResponse.Meals.Take(10))
        {
            // evita duplicati
            if (await _db.Meals.AnyAsync(m => m.ExternalId == mealApi.IdMeal))
                continue;

            var meal = new Meal
            {
                ExternalId = mealApi.IdMeal,
                Name = mealApi.StrMeal,
                Category = mealApi.StrCategory,
                Area = mealApi.StrArea,
                Instructions = mealApi.StrInstructions,
                Thumbnail = mealApi.StrMealThumb
            };

            _db.Meals.Add(meal);
            names.Add(meal.Name);
        }

        if (names.Count > 0)
        {
            await _db.SaveChangesAsync();
            Console.WriteLine($"[SUGGEST][API STORE] {names.Count} elementi salvati");
        }

        return Ok(names);
    }



}