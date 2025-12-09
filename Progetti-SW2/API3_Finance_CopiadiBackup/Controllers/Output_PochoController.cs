using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class Output_PochoController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Crea(PochoCharacter model)
    {
        if (model == null)
            return BadRequest("Il modello non può essere nullo.");

        _context.PochoCharacters.Add(model);  // prepara il record
        await _context.SaveChangesAsync();  // scrive nel database

        return Ok(model);
    }

    // GET: api/<Output_PochoController>
    [HttpGet]
    public IEnumerable<PochoCharacter> Get()
    {
        var outputPochos = _context.PochoCharacters.ToList();
        return outputPochos;
    }
}