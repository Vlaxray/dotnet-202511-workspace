public class SchedaAllenamento
{
    private int _id;
    private string _obbiettivi;
    private DateTime _dataCreazione;
    private Livello _livello;
    private List<Esercizio> _esercizi;
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public int Id { get => _id; set => _id = value; }
    public string Obbiettivi { get => _obbiettivi; set => _obbiettivi = value; }
    public DateTime DataCreazione { get => _dataCreazione; set => _dataCreazione = value; }
    public Livello Livello { get => _livello; set => _livello = value; }
    public List<Esercizio> Esercizi { get => _esercizi; set => _esercizi = value; }

    ///*******//////////////////*********/////////////*********//////////////////////*****
    public SchedaAllenamento(int id, string obbiettivi, DateTime dataCreazione, Livello livello, List<Esercizio> esercizi)
    {
        this._id = id;
        this._obbiettivi = obbiettivi;
        this._dataCreazione = dataCreazione;
        this._livello = Livello;
        this._esercizi = esercizi;
    }
    public SchedaAllenamento() : this(1, "Gara", DateTime.Now, Livello.Principiante, new List<Esercizio>()) { }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public virtual void AggiungiEsercizi()
    {
        this._esercizi.Add(new Esercizio());
        return;
    }
    public void RimuoviEsercizio()
    {
        this._esercizi.Remove(this._esercizi[0]);
    }
    public int CalcolaDurataTotale()
    {
        int durataTotale = 0;
        foreach (var item in this._esercizi)
        {
            durataTotale += item.Serie * item.RecuperoSecondi;
        }
        return durataTotale;
    }
    public string GeneraReport()
    {
        string Report = $"Allenamento di potenza e forza resistente: {this.Obbiettivi}\nData creazione: {this.DataCreazione.ToString("dd/MM/yyyy")}\nLivello: {this.Livello}\nNumero esercizi: {this.Esercizi.Count}\nDurata totale: {this.CalcolaDurataTotale()} secondi.";
        return Report;
    }
    public override string ToString()
    {
        return $"Id: {_id}, Obbiettivi: {_obbiettivi}, Data creazione: {_dataCreazione.ToString("dd/MM/yyyy")}, Livello: {_livello}, Esercizi: {_esercizi.Count}";
    }
}