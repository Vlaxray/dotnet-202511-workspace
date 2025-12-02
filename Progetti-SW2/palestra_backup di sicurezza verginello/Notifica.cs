using System.Collections.Concurrent;

public class Notifica
{
    private int _id;
    private TipoNotifica _tipo;
    private string _messaggio;
    private DateTime _dataInvio;
    private bool _letta;
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public int Id { get => _id; set => _id = value; }
    public TipoNotifica Tipo { get => _tipo; set => _tipo = value; }
    public string Messaggio { get => _messaggio; set => _messaggio = value; }
    public DateTime DataInvio { get => _dataInvio; set => _dataInvio = value; }
    public bool Letta { get => _letta; set => _letta = value; }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public Notifica(int id, TipoNotifica tipo, string messaggio, DateTime dataInvio, bool letta)
    {
        this._id = id;
        this._tipo = tipo;
        this._messaggio = messaggio;
        this._dataInvio = dataInvio;
        this._letta = letta;
    }
    public Notifica() : this(9, TipoNotifica.Sistema, "", new DateTime(), false) { }
    ///*******//////////////////*********/////////////*********//////////////////////*****
    public bool InviaPromemoriaPagamento()
    {
        if (DateTime.Now.Day == 12)
        {
            Console.WriteLine(TipoNotifica.PromemoriaPagamento);

        }
        return true;

    }
    public bool InviaPromemoriaCorso()
    {
        if (DateTime.Now.Day == 9)
        {
            Console.WriteLine(TipoNotifica.PromemoriaCorsi);
        }
        return true;
    }
    public bool InviaOffertaRinnovo()
    {
        if (DateTime.Now.Day == 11)
        {
            Console.WriteLine(TipoNotifica.OffertaRinnovo);
        }
        return true;
    }
    public void SegnaComeLetta()
    {

        if (this._letta)
            Console.WriteLine($"La notifica è stata segnata come letta.");
        else
            Console.WriteLine($"Nuova notifica");

    }
    public string GetDettagli()
    {
        return $"Tipo Notifica:{Tipo}: Contenuto:{Messaggio}";
    }


    public override string ToString()
    {
        return "Id: " + _id + " Tipo: " + _tipo + " Messaggio: " + _messaggio + " Data Invio: " + _dataInvio.ToString("dd/MM/yyyy HH:mm:ss") + " Letta: " + (_letta ? "Sì" : "No");
    }
}
