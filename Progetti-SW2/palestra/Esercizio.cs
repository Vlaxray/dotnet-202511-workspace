public class Esercizio
{
    private int _id;
    private string _nome;
    private string _descrizione;
    private int _serie;
    private int _ripetizioni;
    private int _recuperoSecondi;
    private string _attrezzatura;

    public int Id { get => _id; set => _id = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descrizione { get => _descrizione; set => _descrizione = value; }
    public int Serie { get => _serie; set => _serie = value; }
    public int Ripetizioni { get => _ripetizioni; set => _ripetizioni = value; }
    public int RecuperoSecondi { get => _recuperoSecondi; set => _recuperoSecondi = value; }
    public string Attrezzatura { get => _attrezzatura; set => _attrezzatura = value; }
    public int Tonnellaggio { get; set; }

    public Esercizio(int id, string nome, string descrizione, int serie, int ripetizioni, int recuperoSecondi,
        string attrezzatura)
    {
        this.Id = _id;
        this.Nome = _nome;
        this.Descrizione = _descrizione;
        this.Serie = _serie;
        this.Ripetizioni = _ripetizioni;
        this.RecuperoSecondi = _recuperoSecondi;
        this.Attrezzatura = _attrezzatura;
    }
    public Esercizio() : this(1,"","",1, 1, 1, "") {}
    public void CalcolaCaricoLavoro()
    {
        //10 serie * 14 reps  = tonnellaggio
        Tonnellaggio = this.Serie * this.Ripetizioni;
        System.Console.WriteLine("Il tonnellaggio è " + Tonnellaggio);
        
    }
    public void VerificaDifficolta()
    {
        if (Tonnellaggio > 100) Console.WriteLine("difficile");
        else if(Tonnellaggio < 30) Console.WriteLine("facile");
        else Console.WriteLine("medio");
    }
    public void GetIstruzioni()
    {
        //fornisce istruzioni per l'esercizio
        Console.WriteLine("Slancio a ritmo 14 reps per 1 minuto recupero 1 minuto e mezzo per 14 serie con 2 kettlebell da 24 kg");
    }
    public override string ToString()
    {
        return $"Id: {_id}\nNome: {_nome}\nDescrizione: {_descrizione}\nSerie: {_serie}\nRipetizioni: " +
            $"{_ripetizioni}\nRecupero secondi: {_recuperoSecondi}\nAttrezzatura: {_attrezzatura}\nTonnellaggio: {Tonnellaggio}\nDifficoltà: {VerificaDifficolta}\nIstruzioni: {GetIstruzioni}\n";
    }
}