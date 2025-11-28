using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        e.Id = 2;//2, "Slancio", "Slancio con due Kb", 10, 20, 90, "2x24Kg");
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
 public void TestMetodi(){

    
    Esercizio e2 = new Esercizio();
    e2.Serie = 15;
    e2.Ripetizioni = 12;
    Assert.That(e2.Id, Is.EqualTo(3));
}
}

