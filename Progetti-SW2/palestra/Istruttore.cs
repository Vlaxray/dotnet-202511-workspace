using System.Runtime.InteropServices;

public class Istruttore
{
    private int _id;
    private string _nome;
    private string _cognome;
    private string _specializzazione;
    private DateTime _dataAssunzione;
    private List<Corso> _corsi;
    private Palestra _palestra;
    ///*******//////////////////*********/////////////*********//////////////////////**
    public int Id { get => _id; set => _id = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Cognome { get => _cognome; set => _cognome = value; }
    public string Specializzazione { get => _specializzazione; set => _specializzazione = value; }
    public DateTime DataAssunzione { get => _dataAssunzione; set => _dataAssunzione = value; }
    public List<Corso> Corsi { get => _corsi; set => _corsi = value; }
    public Palestra palestra{ get => _palestra; set => _palestra = value;}
    ///*******//////////////////*********/////////////*********//////////////////////**
    public Istruttore(int id, string nome, string cognome, string specializzazione, DateTime dataAssunzione, Corso corso, Palestra palestra)
    {
        this._id = id;
        this._nome = nome;
        this._cognome = cognome;
        this._specializzazione = specializzazione;
        this._dataAssunzione = dataAssunzione;
        this._corsi = new List<Corso>();
        this._palestra = palestra;
    
    }
    public Istruttore() : this (0, "Nome", "Cognome", "Specializzazione", DateTime.Now, null, null) { }
    ///*******//////////////////*********/////////////*********//////////////////////**
    /// MANCANO  I_METODI
    /// 
    public override string ToString()
    {
        return $"Id: {_id}, Nome: {_nome}, Cognome: {_cognome}, Specializzazione: {_specializzazione}";
    }
}