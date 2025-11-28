using System;
using System.Collections.Generic;

public enum StatoPrenotazione
{
    ATTIVA,
    ANNULLATA,
    COMPLETATA
}

public class Prenotazione
{
    private string? _codicePrenotazione; // XH-8888
    private DateTime _dataPrenotazione;
    private DateTime _dataScadenza;
    private StatoPrenotazione _statoPrenotazione;
    private List<Libro> _libri;

    public string CodicePrenotazione
    {
        get => this._codicePrenotazione!;
        set 
        {
            if(value.Length < 4)
                throw new Exception("il codice prenotazione deve essere almento di 4 caratteri");
            this._codicePrenotazione = value;
        } 
    }

    public DateTime DataPrenotazione
    {
        get => this._dataPrenotazione;
        set => this._dataPrenotazione = value;
    }

    public DateTime DataScadenza
    {
        get => this._dataScadenza;
        set => this._dataScadenza = value;
    }

    public StatoPrenotazione StatoPrenotazione
    {
        get => this._statoPrenotazione;
        set => this._statoPrenotazione = value;
    }

    public List<Libro> Libri
    {
        get => this._libri;
        //set => this._libri = value;
    }

    // Costruttore di default // IMPRECISIONE ---> DOVREI CHIAMARE IL COSTRUTTORE DI SOTTO!!!!!
    public Prenotazione()
    {
        this._codicePrenotazione = this.GeneraCodicePrenotazione(10);
        this._dataPrenotazione = DateTime.Now;
        this._dataScadenza = _dataPrenotazione.AddDays(3); // Scadenza di default è 7 giorni dopo
        this._statoPrenotazione = StatoPrenotazione.ATTIVA; // Stato di default
        this._libri = new List<Libro>(); // Inizializza la lista dei libri
    }


    public void StampaLibri()
    {
        foreach(var libro in this._libri)
            System.Console.WriteLine(libro);
    }


    public bool AggiungiPrenotazioneLibro(Libro libro)
    {
        this._libri.Add(libro);
        return true;
    }

    // Costruttore parametrizzato

    /*
    public Prenotazione(string codicePrenotazione, 
            DateTime dataPrenotazione, DateTime dataScadenza, StatoPrenotazione statoPrenotazione)
    {
        //_codicePrenotazione = codicePrenotazione;
        this.CodicePrenotazione = codicePrenotazione; // STATE FACENDO UN CHECK !! USANDO IL SETTER 


        _dataPrenotazione = dataPrenotazione;       //TO FIX
        _dataScadenza = dataScadenza;               //TO FIX
        _statoPrenotazione = statoPrenotazione;     //TO FIX


        //_libri = libri ?? new List<Libro>(); // Inizializza la lista dei libri, se null
        _libri =  new List<Libro>(); 
    }
    */



    private string GeneraCodicePrenotazione(int cifreCodice)
    {
        string ris = "";
        List<string> myValue = new List<string>(){"a" ,"b" , "c", "d" , "e"};
        Random random = new Random();

        for(int i = 0 ; i < cifreCodice ; i++)
        {
            int valoreScelto = random.Next(0 , myValue.Count);
            ris += myValue[valoreScelto];
        }
        return ris  + random.Next(0 , 10) +  random.Next(0 , 10);
    }



    // Metodo ToString
    public override string ToString()
    {
        string libriString = _libri != null && _libri.Count > 0 
            ? string.Join(", ", _libri.Select(libro => libro.Titolo)) 
            : "Nessun libro prenotato";

        return $"Codice Prenotazione: {CodicePrenotazione}, Data Prenotazione: {DataPrenotazione}, Data Scadenza: {DataScadenza}, Stato: {StatoPrenotazione}, Libri: {libriString}";
    }
}
