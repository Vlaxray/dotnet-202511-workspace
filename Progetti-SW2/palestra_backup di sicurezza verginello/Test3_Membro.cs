
using NUnit.Framework;
public class Tests_3_Membro
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }

    [Test] //Test Attributi
    public void Test1()
    {
        Membro m = new Membro();
        m.Id = 5;
        Assert.That(m.Id, Is.EqualTo(5));
        m.Name = "Giorgione";
        Assert.That(m.Name, Is.EqualTo("Giorgione"));
        m.Cognome = "Trimonti";
        Assert.That(m.Cognome, Is.EqualTo("Trimonti"));
        m.Email = "GiorgioneTrimonti@gail.com";
        Assert.That(m.Email, Is.EqualTo("GiorgioneTrimonti@gail.com"));
        m.Telefono = "+391234567890";
        Assert.That(m.Telefono, Is.EqualTo("+391234567890"));
        m.DataIscrizione = DateTime.Now;
        Assert.That(m.DataIscrizione, Is.EqualTo(DateTime.Now).Within(10000).Milliseconds);
        m.DataNascita = DateTime.Today.AddYears(-20);
        Assert.That(m.DataNascita, Is.EqualTo(DateTime.Today.AddYears(-20)));
    }
    [Test] //Test Metodi
    public void TestMetodiInMembro()
    {
        Membro m2 = new Membro();
        m2.DataIscrizione = DateTime.Now.AddDays(0);
        Assert.That(m2.VerificaAbbonamentoAttivo() ? true : false, Is.True);
        m2.DataNascita = new DateTime(1978, 01, 01);
        Assert.That(m2.CalcolaEta(), Is.EqualTo(47));
        m2.DataIscrizione = DateTime.Today.AddDays(180);
        Assert.That(m2.GetGiorniIscrizione(), Is.EqualTo(179));
        Assert.That(m2.PuoiPrenotareCorso() ? true:false, Is.True);
    }
}