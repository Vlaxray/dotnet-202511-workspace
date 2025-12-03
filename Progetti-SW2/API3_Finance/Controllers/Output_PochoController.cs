using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class Output_PochoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public Output_PochoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Crea(Output_Pocho model)
    {
        if (model == null)
            return BadRequest("Il modello non può essere nullo.");

        _context.Output_Pochos.Add(model);  // prepara il record
        await _context.SaveChangesAsync();  // scrive nel database

        return Ok(model);
    }

    // GET: api/<Output_PochoController>
    [HttpGet]
    public IEnumerable<Output_Pocho> Get()
    {
        var outputPochos = _context.Output_Pochos.ToList();
        return outputPochos;
    }
}