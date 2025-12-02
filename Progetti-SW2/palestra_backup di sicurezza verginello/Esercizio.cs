public class Esercizio
{
    private int _id;
    private string _nome;
    private string _descrizione;
    private int _serie;
    private int _ripetizioni;
    private int _recuperoSecondi;
    private string _attrezzatura;
    ///*******//////////////////*********/////////////*********//////////////////////*****

    public int Id { get => _id; set => _id = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descrizione { get => _descrizione; set => _descrizione = value; }
    public int Serie { get => _serie; set => _serie = value; }
    public int Ripetizioni { get => _ripetizioni; set => _ripetizioni = value; }
    public int RecuperoSecondi { get => _recuperoSecondi; set => _recuperoSecondi = value; }
    public string Attrezzatura { get => _attrezzatura; set => _attrezzatura = value; }
    public int Tonnellaggio { get; set; }
    ///*******//////////////////*********/////////////*********//////////////////////*****

    public Esercizio(int id, string nome, string descrizione, int serie, int ripetizioni, int recuperoSecondi,
        string attrezzatura)
    {
        this.Id = id;
        this.Nome = nome;
        this.Descrizione = descrizione;
        this.Serie = serie;
        this.Ripetizioni = ripetizioni;
        this.RecuperoSecondi = recuperoSecondi;
        this.Attrezzatura = attrezzatura;
    }
    public Esercizio() : this(1,"","",1, 1, 1, "") {}
    ///*******//////////////////*********/////////////*********//////////////////////*****
    
    public void CalcolaCaricoLavoro()
    {
        //10 serie * 14 reps  = tonnellaggio
        Tonnellaggio = this.Serie * this.Ripetizioni;
        Console.WriteLine("Il tonnellaggio è " + Tonnellaggio);
    }
    
    public string VerificaDifficolta()
    {
        if (Tonnellaggio > 100) 
        {
            Console.WriteLine("difficile");
            return "difficile";
        }
        else if(Tonnellaggio < 30) 
        {
            Console.WriteLine("facile");
            return "facile";
        }
        else 
        {
            Console.WriteLine("media");
            return "media";
        }
    }
    
    public string GetIstruzioni()
    {
    //fornisce istruzioni per l'esercizio
      string istruzioni = "Slancio a ritmo 14 reps per 1 minuto recupero 1 minuto e mezzo per 14 serie con 2 kettlebell da 24 kg";
      return istruzioni;
    }
    
    public override string ToString()
    {
        return $"Id: {_id}\nNome: {_nome}\nDescrizione: {_descrizione}\nSerie: {_serie}\nRipetizioni: " +
            $"{_ripetizioni}\nRecupero secondi: {_recuperoSecondi}\nAttrezzatura: {_attrezzatura}\nTonnellaggio: {Tonnellaggio}\nDifficoltà: {this.VerificaDifficolta()}\nIstruzioni: {this.GetIstruzioni()}\n";
    }
}