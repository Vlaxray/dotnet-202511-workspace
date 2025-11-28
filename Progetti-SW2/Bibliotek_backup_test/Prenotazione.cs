public class Prenotazione
{
    public int Codice_Prenotazione { get; set; }
    public DateTime Data_Prenotazione { get; set; }
    public DateTime Data_Scadenza { get; set; }
    public Prenotazione_Stato Stato { get; set; }

    public enum Prenotazione_Stato
    {
        Attiva,
        Annullata,
        Completata
    }
    public Prenotazione(int codice_prenotazione, DateTime data_prenotazione, DateTime data_scadenza, Prenotazione_Stato stato) 
    {
        Codice_Prenotazione = codice_prenotazione;
        Data_Prenotazione = data_prenotazione;
        Data_Scadenza = data_scadenza;
        Stato = stato;
    }
    public Prenotazione() : this(0, DateTime.Now, DateTime.Now.AddDays(3), Prenotazione_Stato.Attiva) { }
    

    public void AttivaPrenotazione()
    {
        if (Stato != Prenotazione_Stato.Annullata && Stato != Prenotazione_Stato.Completata)
        {
            Stato = Prenotazione_Stato.Attiva;
            Data_Prenotazione = DateTime.Now;
            Data_Scadenza = DateTime.Now.AddDays(3);
        }
    }
    public void AnnullaPrenotazione()
    {
        if (Stato != Prenotazione_Stato.Annullata && Stato != Prenotazione_Stato.Completata)
            Stato = Prenotazione_Stato.Annullata;
    }
    public void CompletaPrenotazione()
    {
        if (Stato != Prenotazione_Stato.Completata)
            Stato = Prenotazione_Stato.Completata;
    }
}
