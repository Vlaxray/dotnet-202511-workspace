using NUnit.Framework;

public class Palestra
{
    private string _nome;
    private string _indirizzo;
    private string _telefono;
    private int _capienzaMassima;
    private List<Istruttore> _istruttori;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string Nome { get => _nome; set => _nome = value; }
    public string Indirizzo { get => _indirizzo; set => _indirizzo = value; }
    public string Telefono { get => _telefono; set => _telefono = value; }
    public int CapienzaMassima { get => _capienzaMassima; set => _capienzaMassima = value; }
    public List<Istruttore> Istruttori { get => _istruttori; set => _istruttori = value; }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Palestra(string nome, string indirizzo, string telefono, int capienzaMassima, List<Istruttore> istruttori)
    {
        this._nome = nome;
        this._indirizzo = indirizzo;
        this._telefono = telefono;
        this._capienzaMassima = capienzaMassima;
        this._istruttori = new List<Istruttore>();
    }
    public Palestra() : this( "Palestra Dei Forti", "via dei Fortificanti", "+991234567890", 5, new List<Istruttore>() )  { }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override string ToString()
    {
        return $"Nome: {_nome}, Indirizzo: {_indirizzo}, Numero Istruttori: {_istruttori.Count}";
    }
}