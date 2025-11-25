public class Libro
{
    public string Titolo { get; set; }
    public int Pagine { get; set; }

    public Libro() : this("Titolo", 1) { }

    public Libro(string titolo, int pagine)
    {
        this.Titolo = titolo;
        this.Pagine = pagine;
    }

    public override string ToString()
    {
        return $"{Titolo} ({Pagine} pagine)";
    }
}
