using NUnit.Framework;
public class Tests2
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }
    [Test]
    public void Test1()
    {
        SchedaAllenamento s = new SchedaAllenamento();
        s.Id = 3;
        Assert.That(s.Id, Is.EqualTo(3));
        s.Obbiettivi = "Gara il 28 Nov";
        Assert.That(s.Obbiettivi, Is.EqualTo("Gara il 28 Nov"));
        s.DataCreazione = DateTime.Now;
        Assert.That(s.DataCreazione.Date, Is.EqualTo(DateTime.Today));
        s.Livello = 2;
        Assert.That(s.Livello, Is.EqualTo(2));
        s.Esercizi = new List<Esercizio>();
        for(int i = 0; i < 20; i++)
        {
            s.Esercizi.Add(new Esercizio());
        }
        Assert.That(s.Esercizi.Count, Is.EqualTo(20));
    }
}