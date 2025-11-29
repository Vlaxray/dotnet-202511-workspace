
using NUnit.Framework;
public class Tests_4_Notifica
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }

    [Test] //Test Attributi
    public void Test4()
    {
        Notifica n = new Notifica();
        n.Id = 22;
        Assert.That(n.Id, Is.EqualTo(22));
        n.Tipo = TipoNotifica.OffertaRinnovo;
        Assert.That(n.Tipo, Is.EqualTo(TipoNotifica.OffertaRinnovo));
        n.Messaggio = "Ciao";
        Assert.That(n.Messaggio, Is.EqualTo("Ciao"));
        n.DataInvio = DateTime.Now;
        Assert.That(n.DataInvio, Is.EqualTo(DateTime.Now).Within(10000).Milliseconds);
        n.Letta = true;
        Assert.That(n.Letta, Is.True);
        n.Letta = false;
        Assert.That(n.Letta, Is.False);
    }
    [Test] //Test Metodi
    public void TestMetodiInNotifica()
    {
        Notifica n2 = new Notifica();
        n2.Tipo = TipoNotifica.PromemoriaPagamento;
        Assert.That(n2.Tipo, Is.EqualTo(TipoNotifica.PromemoriaPagamento));
        bool result = n2.InviaPromemoriaPagamento();
        Assert.That(result, Is.True);

        n2 = new Notifica();
        n2.Tipo = TipoNotifica.OffertaRinnovo; 
        bool result2 = n2.InviaOffertaRinnovo();
        Assert.That(result2, Is.True);
        Assert.That(n2.Tipo, Is.EqualTo(TipoNotifica.OffertaRinnovo));

        n2 = new Notifica();
        n2.Tipo = TipoNotifica.PromemoriaCorsi; 
        bool result3 = n2.InviaPromemoriaCorso();
        Assert.That(result);
        Assert.That(n2.Tipo, Is.EqualTo(TipoNotifica.PromemoriaCorsi));
        n2.SegnaComeLetta();    
        Assert.That(n2.Letta, Is.False);
        n2.Letta = true;
        Assert.That(n2.Letta, Is.True);
        n2.GetDettagli();
    }
}