public class PartecipazioneCorso
{
    private int _id;
    private DateTime _data;
    private bool _presente;
    private Corso? _corso;
    private Membro? _membro;

    public int Id { get => _id; set => _id = value; }
    public DateTime Data { get => _data; set => _data = value; }
    public bool Presente { get => _presente; set => _presente = value; }
    public Corso Corso
    {
        get => _corso ?? throw new InvalidOperationException("Corso non inizializzato");
        set => _corso = value;
    }
    public Membro Membro
    {
        get => _membro ?? throw new InvalidOperationException("Membro non inizializzato");
        set => _membro = value;
    }

    public PartecipazioneCorso(int id, DateTime data, bool presente, Corso corso, Membro membro)
    {
        _id = id;
        _data = data;
        _presente = presente;
        _corso = corso ?? throw new ArgumentNullException(nameof(corso));
        _membro = membro ?? throw new ArgumentNullException(nameof(membro));
    }

    // Costruttore vuoto inizializza campi sicuri
    public PartecipazioneCorso()
    {
        _id = 0;
        _data = DateTime.Now;
        _presente = false;
        _corso = null;
        _membro = null;
    }

    public void RegistraPresenza()
    {
        if (_membro == null || _corso == null)
            throw new InvalidOperationException("Membro o corso non inizializzato");

        if (Presente)
        {
            Console.WriteLine($"Il membro {_membro.Name} è stato registrato alle ore {DateTime.Now:HH:mm} come presente al corso {_corso}");
        }
    }

    public decimal VerificaFrequenza()
    {
        if (_membro == null || _corso == null || _corso.Partecipazioni == null)
            return 0;

        decimal totaleMinuti = 0;

        foreach (var partecipazione in _corso.Partecipazioni)
        {
            if (partecipazione.Membro != null &&
                _membro.Id == partecipazione.Membro.Id &&
                partecipazione.Presente)
            {
                var orarioInizio = TimeSpan.Parse(_corso.Orario);
                totaleMinuti += (partecipazione.Data.Hour * 60 + partecipazione.Data.Minute)
                                - (orarioInizio.Hours * 60 + orarioInizio.Minutes);
            }
        }

        return totaleMinuti / 60m; // Divisione sicura decimal
    }

    public override string ToString()
    {
        string corsoStr = _corso?.ToString() ?? "N/D";
        string membroStr = _membro?.ToString() ?? "N/D";
        return $"Id:{_id},Data:{_data:dd/MM/yyyy},Presente:{_presente},Corso:{corsoStr},Membro:{membroStr}";
    }
}
