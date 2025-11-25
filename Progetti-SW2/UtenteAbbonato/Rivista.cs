public class Rivista : Libro
{
    public int Numero { get; set; }
    public Rivista(string titolo, int pagine, int numero) : base(titolo, pagine)
    {
        this.Numero = numero;
    }
    public Rivista() : this("RivistaDelMese", 0, 1) {}
    public override string ToString()
    {
        return base.ToString() + this.Numero;
    }
}