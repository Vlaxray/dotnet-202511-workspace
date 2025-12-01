using NUnit.Framework;
using System;

public class Tests_Istruttore
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }
    
    [Test] // Test Attributi
    public void Test1()
    {
        Istruttore i = new Istruttore();
        i.Id = 5;
        Assert.That(i.Id, Is.EqualTo(5));
        i.Nome = "Mario";
        Assert.That(i.Nome, Is.EqualTo("Mario"));
        i.Cognome = "Rossi";
        Assert.That(i.Cognome, Is.EqualTo("Rossi"));
        i.Specializzazione = "Fitness";
        Assert.That(i.Specializzazione, Is.EqualTo("Fitness"));
        DateTime dataTest = new DateTime(2020, 5, 15);
        i.DataAssunzione = dataTest;
        Assert.That(i.DataAssunzione, Is.EqualTo(dataTest));
    }
    
    [Test] // Test Metodi
    public void TestMetodiInIstruttore()
    {
        Palestra p = new Palestra();
        Istruttore i2 = new Istruttore(1, "Luca", "Verdi", "Yoga", new DateTime(2019, 3, 10), null, p);
        
        // Test GetCorsiInsegnati con lista vuota
        var corsi = i2.GetCorsiInsegnati();
        Assert.That(corsi, Is.Not.Null);
        
        // Aggiungi corsi
        Corso c1 = new Corso();
        c1.Orario = "09:00-10:00";
        c1.DurataMinuti = 60;
        i2.Corsi.Add(c1);
        
        Corso c2 = new Corso();
        c2.Orario = "14:00-15:30";
        c2.DurataMinuti = 90;
        i2.Corsi.Add(c2);
        
        // Test CalcolaOreLavorative
        double ore = i2.CalcolaOreLavorative();
        Assert.That(ore, Is.EqualTo(2)); // 60 + 90 = 150 minuti = 2 ore
        
        // Test VerificaDisponibilitaOrario - disponibile
        bool disponibile1 = i2.VerificaDisponibilitaOrario("11:00-12:00");
        Assert.That(disponibile1, Is.True);
        
        // Test VerificaDisponibilitaOrario - non disponibile (sovrapposizione)
        bool disponibile2 = i2.VerificaDisponibilitaOrario("09:30-10:30");
        Assert.That(disponibile2, Is.False);
        
        // Test VerificaDisponibilitaOrario - non disponibile (stesso orario)
        bool disponibile3 = i2.VerificaDisponibilitaOrario("14:00-15:30");
        Assert.That(disponibile3, Is.False);
        
        // Test GetCorsiInsegnati con corsi
        var corsiInsegnati = i2.GetCorsiInsegnati();
        Assert.That(corsiInsegnati, Is.Not.Null);
    }
}