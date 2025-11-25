public class UtenteAbbonato : Utente
{
    public UtenteAbbonato(string nome, int massimoPagineInPrestito) : base(nome, massimoPagineInPrestito)
    {
        Nome = nome;
        MassimoPagineInPrestito = massimoPagineInPrestito;
    }

    public UtenteAbbonato() : this("UtenteGenericoJohnDoe", 10) { }
    public override bool PrendiInPrestito(Libro libro)
    {
        if (libro is Rivista)
        {
            this.LibriInPrestito.Add(libro);
            return true;
        }
        return base.PrendiInPrestito(libro);
    }


}