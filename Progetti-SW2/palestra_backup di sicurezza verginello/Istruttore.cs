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
    public Palestra palestra { get => _palestra; set => _palestra = value; }
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
    public Istruttore() : this(0, "Nome", "Cognome", "Specializzazione", DateTime.Now, null, null) { }
    ///*******//////////////////*********/////////////*********//////////////////////**
    public object GetCorsiInsegnati()
    {
        return _corsi;
    }
    public bool VerificaDisponibilitaOrario(string orarioRichiesto)
    {
        // orarioRichiesto es. "17:00-18:00"

        var partiRichieste = orarioRichiesto.Split('-');
        var richiestoInizio = TimeSpan.Parse(partiRichieste[0]);
        var richiestoFine = TimeSpan.Parse(partiRichieste[1]);

        foreach (var corso in _corsi)
        {
            // Ogni corso ha un orario es. "18:00-19:00"
            var partiCorso = corso.Orario.Split('-');
            var corsoInizio = TimeSpan.Parse(partiCorso[0]);
            var corsoFine = TimeSpan.Parse(partiCorso[1]);

            bool sovrapposto =
                richiestoInizio < corsoFine &&
                richiestoFine > corsoInizio;

            if (sovrapposto)
                return false; // orario occupato
        }

        return true; // nessuna sovrapposizione → disponibile
    }
    public double CalcolaOreLavorative(bool decimali = false)
    {
        if (_corsi == null || _corsi.Count == 0)
            return decimali ? 0.0 : 0;

        int totaleMinuti = 0;
        foreach (var corso in _corsi)
            if (corso != null) totaleMinuti += corso.DurataMinuti;

        if (decimali)
            return (double)totaleMinuti / 60.0;
        else
            return totaleMinuti / 60; // divisione intera, cast implicito a double se necessario
    }

    public override string ToString()
    {
        return $"Id: {_id}, Nome: {_nome}, Cognome: {_cognome}, Specializzazione: {_specializzazione}";
    }
}