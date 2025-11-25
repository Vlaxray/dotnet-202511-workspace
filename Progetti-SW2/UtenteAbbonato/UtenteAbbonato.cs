public class UtenteAbbonato : Utente
{
    public UtenteAbbonato(string nome, int massimoPagineInPrestito) : base(nome, massimoPagineInPrestito)
    {
        Nome = nome;
        MassimoPagineInPrestito = massimoPagineInPrestito;
    }

    public UtenteAbbonato() : this("UtenteGenericoJohnDoe", 10) {}
    public bool PrendiInPrestito()
    {
        return true;
    }
    
    
}