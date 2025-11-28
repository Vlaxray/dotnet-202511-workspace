using NUnit.Framework;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Prenota_ImpostaLibroPrenotato()
    {
        var libro = new Libro { Titolo = "Dune" };
        var utente = new Utente();

        utente.PrenotaLibro(libro);

        Assert.That(utente.LibroPrenotato, Is.EqualTo(libro));
    }
    [Test]

    public void AnnullaPrenotazione_RimuoveLibro()
    {
        var libro = new Libro { Titolo = "Dune" };
        var utente = new Utente();
        utente.PrenotaLibro(libro);

        utente.AnnullaPrenotaLibro();

        Assert.That(utente.LibroPrenotato, Is.Null);
    }
}

