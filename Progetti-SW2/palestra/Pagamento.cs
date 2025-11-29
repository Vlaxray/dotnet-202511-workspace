using System;

public class Pagamento
{
    private int _id;
    private DateTime _data;
    private decimal _importo;
    private string _metodoPagamento;
    private bool _pagato;
    private Abbonamento? _abbonamento;
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public int Id { get => _id; set => _id = value; }
    public DateTime Data { get => _data; set => _data = value; }
    public decimal Importo { get => _importo; set => _importo = value; }
    public string MetodoPagamento { get => _metodoPagamento; set => _metodoPagamento = value; }
    public bool Pagato { get => _pagato; set => _pagato = value; }
    public Abbonamento Abbonamento
    {
        get { return _abbonamento; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Abbonamento non può essere nullo");

            _abbonamento = value;
        }
    }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public Pagamento(int id, DateTime data, decimal importo, string metodoPagamento, bool pagato, Abbonamento abbonamento)
    {
        this._id = id;
        this._data = data;
        this._importo = importo;
        this._metodoPagamento = metodoPagamento;
        this._pagato = pagato;
        this._abbonamento = abbonamento;
    }
    public Pagamento() : this(0, DateTime.Now, 0.0m, "", false, null) { }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public void EseguiPagamento()
    {
        if (_abbonamento == null)
            throw new InvalidOperationException("Pagamento non associato a nessun abbonamento.");
        
        if (this.Pagato)
        {
            Console.WriteLine($"Il pagamento ID {_id} è già stato eseguito.");
            return;
        }
        
        this.Pagato = true;
        this.Data = DateTime.Now;
        
        // Se l'abbonamento non è ancora attivo, lo attiviamo
        if (_abbonamento.DataScadenza == null || _abbonamento.IsScaduto())
        {
            _abbonamento.DataInizio = DateTime.Now;
            
            // Calcola la scadenza in base al tipo
            if (_abbonamento.Tipo == TipoAbbonamento.Base)
                _abbonamento.DataScadenza = DateTime.Now.AddMonths(3);
            else if (_abbonamento.Tipo == TipoAbbonamento.Premium)
                _abbonamento.DataScadenza = DateTime.Now.AddMonths(6);
            else
                _abbonamento.DataScadenza = DateTime.Now.AddYears(1);
        }
        
        Console.WriteLine($"Pagamento ID {_id} eseguito il {this.Data.ToShortDateString()}. Abbonamento attivato fino al {_abbonamento.DataScadenza?.ToShortDateString()}.");
    }
    
    public bool VerificaScadenzaPagamento()
    {
        // Se il pagamento è già eseguito, non può essere scaduto
        if (this.Pagato)
            return false;

        // Data è la data di creazione del pagamento
        DateTime dataRiferimento = this.Data;

        // Se la data è default, uso DateTime.Now
        if (dataRiferimento == default(DateTime))
            dataRiferimento = DateTime.Now;

        // Controllo scadenza a 30 giorni
        if (dataRiferimento.AddDays(30) < DateTime.Now)
        {
            Console.WriteLine($"Attenzione! Il pagamento con ID {_id} è scaduto.");
            return true;
        }

        return false;
    }
    
    public string GeneraRicevuta()
    {
        return $"============== RICEVUTA DI PAGAMENTO ==============\n" +
               $"ID Pagamento: {_id}\n" +
               $"Data: {this.Data.ToString("dd/MM/yyyy HH:mm")}\n" +
               $"Importo: {_importo:C}\n" +
               $"Metodo di pagamento: {(_metodoPagamento != "" ? _metodoPagamento : "Non specificato")}\n" +
               $"Stato: {(this.Pagato ? "ESEGUITO" : "IN SOSPESO")}\n" +
               $"{(_abbonamento != null ? $"\n--- Abbonamento Associato ---\n{_abbonamento.ToString()}" : "Nessun abbonamento associato")}\n" +
               $"===================================================";
    }

    public override string ToString()
    {
        return $"[Pagamento #{_id}] Data: {_data.ToString("dd/MM/yyyy")} | Importo: {_importo:C} | " +
               $"Metodo: {(_metodoPagamento != "" ? _metodoPagamento : "Non specificato")} | " +
               $"Stato: {(this.Pagato ? "Eseguito" : "In sospeso")} | " +
               $"Abbonamento: {(_abbonamento != null ? $"ID {_abbonamento.Id} - {_abbonamento.Tipo}" : "Nessuno")}";
    }
}