public class Libro
{
    public string Isbn { get; set; }
    public string Titolo { get; set; }
    public string Autore { get; set; }
    public int Anno_Pubblicazione { get; set; }
    public Stato stato { get; set; }

    public DateTime? DataScadenza { get; private set; } // data di scadenza prenotazione

    public enum Stato
    {
        Disponibile,
        Prenotata,
        InPrestito
    }

    public Libro(string isbn, string titolo, string autore, int anno_pubblicazione, Stato Stato)
    {
        this.Isbn = isbn;
        this.Titolo = titolo;
        this.Autore = autore;
        this.Anno_Pubblicazione = anno_pubblicazione;
        this.stato = Stato;
    }

    public Libro() : this("", "", "", 0, Stato.Disponibile) { }

    // Metodo per prenotare il libro
    public void Prenota()
    {
        if (stato == Stato.Disponibile)
        {
            stato = Stato.Prenotata;
            DataScadenza = DateTime.Now.AddDays(3); // scadenza tra 3 giorni
            Console.WriteLine($"Libro prenotato, scadenza: {DataScadenza}");
        }
        else
        {
            Console.WriteLine("Libro non disponibile per la prenotazione.");
        }
    }

    // Metodo per annullare la prenotazione
    public void AnnullaPrenotazione()
    {
        if (stato == Stato.Prenotata)
        {
            stato = Stato.Disponibile;
            DataScadenza = null;
            Console.WriteLine("Prenotazione annullata.");
        }
    }

    public override string ToString()
    {
        return $"{Isbn} - {Titolo} - {Autore} - {Anno_Pubblicazione} - {stato} " +
               (DataScadenza.HasValue ? $"- Scadenza: {DataScadenza.Value}" : "");
    }
}
