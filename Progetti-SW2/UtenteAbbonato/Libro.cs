public class Libro
{
    public string Titolo { get; set; }
    public int Pagine { get; set; }

    public Libro() : this("Titolo", 1) { }

    public Libro(string titolo, int pagine)
    {
        Titolo = titolo;
        Pagine = pagine;
    }

    public override string ToString()
    {
        return $"{Titolo} ({Pagine} pagine)";
    }
}
