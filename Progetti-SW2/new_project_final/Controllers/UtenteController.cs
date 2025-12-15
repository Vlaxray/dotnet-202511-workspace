using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class UtentiController : Controller
{
    // GET: /Utenti/Lista
    public ActionResult Lista()
    {
        var utenti = new List<Utente>
        {
            new Utente { Id = 1, Nome = "Mario Rossi", Email = "mario@example.com" },
            new Utente { Id = 2, Nome = "Luigi Bianchi", Email = "luigi@example.com" }
        };

        return Json(utenti);
    }
}