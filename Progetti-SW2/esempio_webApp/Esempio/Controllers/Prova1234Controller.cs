using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Esempio.Models;

namespace Esempio.Controllers;

public class Prova1234Controller: Controller
{
    public IActionResult Index()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
