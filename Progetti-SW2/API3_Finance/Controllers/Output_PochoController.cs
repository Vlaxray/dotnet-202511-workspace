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
        _context.Output_Pochos.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }
}
