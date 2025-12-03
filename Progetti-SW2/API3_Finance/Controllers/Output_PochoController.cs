using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class Output_PochoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public Output_PochoController(ApplicationDbContext context)
    {
        _context = context; // qui basta assegnare
    }

    [HttpPost]
    public async Task<IActionResult> Crea(Output_Pocho model)
    {
        if (model == null)
            return BadRequest("Il modello non può essere nullo.");

        _context.Output_Pochos.Add(model);
        await _context.SaveChangesAsync(); // qui salvi davvero

        return Ok(model);
    }
}
