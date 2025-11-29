
using NUnit.Framework;
public class Tests
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }
    
    [Test]
    public void Test1()
    {
        Esercizio e = new Esercizio();
        e.Id = 2;
        Assert.That(e.Id, Is.EqualTo(2));
        e.Nome = "Slancio";
        Assert.That(e.Nome, Is.EqualTo("Slancio"));
        e.Descrizione = "Slancio con due Kb";
        Assert.That(e.Descrizione, Is.EqualTo("Slancio con due Kb"));
        e.Serie = 10;
        Assert.That(e.Serie, Is.EqualTo(10));
        e.Ripetizioni = 20;
        Assert.That(e.Ripetizioni, Is.EqualTo(20));
        e.RecuperoSecondi = 90;
        Assert.That(e.RecuperoSecondi, Is.EqualTo(90));
        e.Attrezzatura = "2x24Kg";
        Assert.That(e.Attrezzatura, Is.EqualTo("2x24Kg"));
    }
    [Test]
    public void TestMetodiInEsercizio()
    {
        Esercizio e2 = new Esercizio();
        e2.Serie = 15;
        e2.Ripetizioni = 12;
        
        e2.CalcolaCaricoLavoro();
        Assert.That(e2.Tonnellaggio, Is.EqualTo(180));
        
        string difficolta = e2.VerificaDifficolta();
        Assert.That(difficolta, Is.EqualTo("difficile"));
        
        var istruzioni_test= e2.GetIstruzioni();
        Assert.That(istruzioni_test, Is.EqualTo("Slancio a ritmo 14 reps per 1 minuto recupero 1 minuto e mezzo per 14 serie con 2 kettlebell da 24 kg"));
    }
}