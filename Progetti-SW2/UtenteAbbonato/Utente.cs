public class Utente
{
    public string Nome { get; set; }
    private int _massimoPagineInPrestito;
    public List<Libro> LibriInPrestito;

    public Utente() : this("", 1) { }

    public Utente(string nome, int massimoPagineInPrestito)
    {
        this.Nome = nome;
        this.MassimoPagineInPrestito = massimoPagineInPrestito;
        this.LibriInPrestito = new List<Libro>();
    }

    public int MassimoPagineInPrestito
    {
        get => _massimoPagineInPrestito;
        set
        {
            if (value > 600)
            {
                _massimoPagineInPrestito = 599;
               
            }
            else
                _massimoPagineInPrestito = value;
        }
    }

    public virtual bool PrendiInPrestito(Libro libro)
    {
        int totalePagine = LibriInPrestito.Sum(l => l.Pagine) + libro.Pagine;
        if (totalePagine > MassimoPagineInPrestito || LibriInPrestito.Contains(libro))
            return false;

        LibriInPrestito.Add(libro);
        return true;
    }

    public void RestituisciLibro(Libro libro)
    {
        if (LibriInPrestito.Contains(libro))
            LibriInPrestito.Remove(libro);
    }

    public override string ToString()
    {
        if (LibriInPrestito.Count == 0)
            return $"{Nome} non ha libri in prestito.";
        return $"{Nome} ha in prestito:\n" +
               string.Join("\n", LibriInPrestito.Select(l => "- " + l));
    }
}
