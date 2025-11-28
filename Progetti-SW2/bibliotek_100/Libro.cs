
public enum StatoLibro
{
    DISPONIBILE,
    IN_PRESTITO,
    NON_DISPONIBILE
}


public class Libro
{
    private string _isbn;
    private string _titolo;
    private string _autore;
    private int _annoPubblicazione;

    private StatoLibro _statoLibro;

    public string Isbn 
    { 
        get => this._isbn; 
        set => this._isbn = value; 
    }

    public string Titolo 
    { 
        get => this._titolo; 
        set => this._titolo = value; 
    }

    public string Autore 
    { 
        get => this._autore; 
        set => this._autore = value; 
    }

    public int AnnoPubblicazione 
    { 
        get => this._annoPubblicazione; 
        set
        {
            if (value < 1800)
                this._annoPubblicazione = 1800;
            else
                this._annoPubblicazione = value;      
        } 
    }

   
    public StatoLibro StatoLibro // Proprietà per lo stato del libro
    {
        get => this._statoLibro;
        set => this._statoLibro = value;
    }

    // Costruttore di default
    public Libro() : this(string.Empty ,string.Empty , string.Empty , 1800 )
    {
    }

    // Costruttore parametrizzato
    public Libro(string isbn, string titolo, string autore, int annoPubblicazione)
    {
        _isbn = isbn;
        _titolo = titolo;
        _autore = autore;
        AnnoPubblicazione = annoPubblicazione; // Usa il setter per controllare il valore
        _statoLibro = StatoLibro.DISPONIBILE; // Stato di default

    }

    // Metodo ToString
    public override string ToString()
    {
        return $"ISBN: {Isbn}, Titolo: {Titolo}, Autore: {Autore}, Anno di Pubblicazione: {AnnoPubblicazione}";
    }
}
