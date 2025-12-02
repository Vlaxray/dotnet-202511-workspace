public class Abbonamento
{
    private int _id;
    private TipoAbbonamento _tipo;
    private DateTime _dataInizio;
    private DateTime? _dataScadenza;
    private decimal _prezzo;
    private List<Pagamento> _pagamenti;
    private StatoAbbonamento _stato = StatoAbbonamento.Non_Attivo;
    ///*******//////////////////*********/////////////*********//////////////////////**
    public int Id { get => _id; set => _id = value; }
    public TipoAbbonamento Tipo { get => _tipo; set => _tipo = value; }
    public DateTime DataInizio { get => _dataInizio; set => _dataInizio = value; }
    public DateTime? DataScadenza { get => _dataScadenza; set => _dataScadenza = value; }
    public decimal Prezzo { get => _prezzo; set => _prezzo = value; }  
    public List<Pagamento> Pagamenti { get => _pagamenti; set => _pagamenti = value; }
    public StatoAbbonamento Stato { get; set; }
    ///*******//////////////////*********/////////////*********//////////////////////**
    public Abbonamento(int id, TipoAbbonamento tipo, DateTime dataInizio, DateTime? dataScadenza, decimal prezzo)
    {
        this._id = id;
        this._tipo = tipo;
        this._dataInizio = dataInizio;
        this._dataScadenza = dataScadenza;
        this._prezzo = prezzo;
        this._pagamenti = new List<Pagamento>();
    }
    public Abbonamento() : this(0, TipoAbbonamento.VIP, DateTime.Now, null, 0.00m) { }
    ///*******//////////////////*********/////////////*********//////////////////////**
    public override string ToString()
    {
        return $"Id: {_id}, Tipo: {_tipo}, Data Inizio: {_dataInizio.ToString("dd/MM/yyyy")}, Data Scadenza: {(DataScadenza == null ? "Nessuna" : ((DateTime)DataScadenza).ToString("dd/MM/yyyy"))}, Prezzo: {_prezzo:C}";
    }
    ///*******//////////////////*********/////////////*********//////////////////////**
    public bool IsScaduto()
    {
        if(DataScadenza != null && DataScadenza < DateTime.Now)
            return true;
        return false;
    }
    public int CalcolaGiorniRimanenti()
    {
        if(IsScaduto() || DataScadenza == null)
            return 0;
        else
            return (int)((DateTime)DataScadenza - DateTime.Now).TotalDays;
    }
    public void Rinnova()
    {// Determina la nuova data di inizio (data scadenza precedente o data corrente)
        DateTime nuovaDataInizio = DataScadenza ?? DateTime.Now;
        
        // Calcola la nuova data di scadenza in base al tipo di abbonamento
        DateTime nuovaDataScadenza;
        if(_tipo == TipoAbbonamento.Base)
        {
            nuovaDataScadenza = nuovaDataInizio.AddMonths(3);
        }
        else if(_tipo == TipoAbbonamento.Premium)
        {
            nuovaDataScadenza = nuovaDataInizio.AddMonths(6);
        }
        else // VIP o altri tipi
        {
            nuovaDataScadenza = nuovaDataInizio.AddYears(1);
        }
        
        // Aggiorna le date dell'abbonamento
        _dataInizio = nuovaDataInizio;
        _dataScadenza = nuovaDataScadenza;
    }
}