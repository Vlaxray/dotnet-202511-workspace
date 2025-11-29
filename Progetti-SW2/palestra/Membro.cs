public class Membro
{
    private int _id;
    private string _name;
    private string _cognome;
    private string _email;
    private string _telefono;
    private DateTime _dataIscrizione;
    private DateTime _dataNascita;
    private SchedaAllenamento _schedaAllenamento;
    private Abbonamento _abbonamento;
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string Cognome { get => _cognome; set => _cognome = value; }
    public string Email { get => _email; set => _email = value; }
    public string Telefono { get => _telefono; set => _telefono = value; }
    public DateTime DataIscrizione { get => _dataIscrizione; set => _dataIscrizione = value; }
    public DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }
    public SchedaAllenamento SchedaAllenamento { get => _schedaAllenamento; set => _schedaAllenamento = value; }
    public Abbonamento Abbonamento { get => _abbonamento; set => _abbonamento = value; }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public Membro(int id, string name, string cognome, string email, string telefono, DateTime dataiscrizione, DateTime datanascita)
    {
        this._id = id;
        this._name = name;
        this._cognome = cognome;
        this._email = email;
        this._telefono = telefono;
        this._dataIscrizione = dataiscrizione;
        this._dataNascita = datanascita;
        this._abbonamento = new Abbonamento();
        this._schedaAllenamento = new SchedaAllenamento();
    }
    public Membro() : this(1, "", "", "", "", DateTime.Now, DateTime.Now) { }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public bool VerificaAbbonamentoAttivo()
    {
        //se non è scaduto resta attivo
        return true;
    }
    public int CalcolaEta()
    {
        TimeSpan ts = DateTime.Now - _dataNascita;
        return (int)(ts.TotalDays / 365.24);
    }
    public int GetGiorniIscrizione()
    {
        TimeSpan ts = _dataIscrizione - DateTime.Now;
        return (int)(ts.TotalDays);
    }
    public bool PuoiPrenotareCorso()
    {
        int eta = 6;
        if ((CalcolaEta() >= eta) && VerificaAbbonamentoAttivo())
            return true;
        else
            return false;
    }
}