using NUnit.Framework;
public class Tests_2_Scheda_Allenamento
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }
    [Test] //Test attributi
    public void Test1()
    {
        SchedaAllenamento s = new SchedaAllenamento();
        s.Id = 3;
        Assert.That(s.Id, Is.EqualTo(3));
        s.Obbiettivi = "Gara il 28 Nov";
        Assert.That(s.Obbiettivi, Is.EqualTo("Gara il 28 Nov"));
        s.DataCreazione = DateTime.Now;
        Assert.That(s.DataCreazione.Date, Is.EqualTo(DateTime.Today));
        s.Livello = Livello.Avanzato ;
        Assert.That(s.Livello, Is.EqualTo(Livello.Avanzato));
        s.Esercizi = new List<Esercizio>();
        for (int i = 0; i < 20; i++)
        {
            s.Esercizi.Add(new Esercizio());
        }
        Assert.That(s.Esercizi.Count, Is.EqualTo(20));
    }
    [Test] //Test Metodi
    public void TestMetodiInSchedaAllenamento()
    {
        SchedaAllenamento s = new SchedaAllenamento();
        int countPrima = s.Esercizi.Count;
        s.AggiungiEsercizi();
        Assert.That(s.Esercizi.Count, Is.EqualTo(countPrima + 1));
        Assert.That(s.Esercizi.Last(), Is.TypeOf<Esercizio>());
        int countDopo = s.Esercizi.Count;
        s.RimuoviEsercizio();
        Assert.That(s.Esercizi.Count, Is.EqualTo(countDopo - 1));
        // Creo esercizi con valori noti
        s.Esercizi.Add(new Esercizio { Serie = 3, RecuperoSecondi = 60 });  // 3 * 60 = 180
        s.Esercizi.Add(new Esercizio { Serie = 2, RecuperoSecondi = 45 });  // 2 * 45 = 90
        s.Esercizi.Add(new Esercizio { Serie = 1, RecuperoSecondi = 30 });  // 1 * 30 = 30
        int durataTotale = s.CalcolaDurataTotale();
        Assert.That(durataTotale, Is.EqualTo(300));
        string report = s.GeneraReport();
        Assert.That(report.Length > 0);
    }
}
