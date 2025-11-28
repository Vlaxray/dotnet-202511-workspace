using System;

public class Utente
{
    public string Uuid { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Email { get; set; }
    public string NumeroDiTessera { get; set; }

    // Riferimento al libro prenotato, null se nessuno
    public Libro? LibroPrenotato { get; private set; }

    public Utente(string uuid, string nome, string cognome, string email, string numeroDiTessera)
    {
        Uuid = uuid;
        Nome = nome;
        Cognome = cognome;
        Email = email;
        NumeroDiTessera = numeroDiTessera;
    }

    public Utente() : this("001", "Giorgio", "Rossi", "giorgiorossi@giorgio.com", "n° 0123456789") { }

    // Prenota un libro (un solo libro per utente)
    public void PrenotaLibro(Libro libro)
    {
        if (LibroPrenotato == null)
        {
            LibroPrenotato = libro;
            libro.stato = Libro.Stato.Prenotata;
            Console.WriteLine($"Hai prenotato il libro: {libro.Titolo}");
        }
        else
        {
            Console.WriteLine("Hai già un libro prenotato.");
        }
    }

    // Prendi il libro prenotato
    public void PrendiLibro()
    {
        if (LibroPrenotato != null)
        {
            Console.WriteLine($"Hai preso il libro: {LibroPrenotato.Titolo}");
            LibroPrenotato.stato = Libro.Stato.InPrestito;
            LibroPrenotato = null; // libro preso, libera la prenotazione
        }
        else
        {
            Console.WriteLine("Non hai prenotato nessun libro.");
        }
    }

    // Annulla la prenotazione
    public void AnnullaPrenotaLibro()
    {
        if (LibroPrenotato != null)
        {
            Console.WriteLine($"Prenotazione annullata per il libro: {LibroPrenotato.Titolo}");
            LibroPrenotato.stato = Libro.Stato.Disponibile;
            LibroPrenotato = null;
        }
        else
        {
            Console.WriteLine("Non hai prenotazioni attive.");
        }
    }

    public override string ToString()
    {
        return $"Uuid: {Uuid}, Nome: {Nome}, Cognome: {Cognome}, Email: {Email}, Numero di tessera: {NumeroDiTessera}";
    }
}
