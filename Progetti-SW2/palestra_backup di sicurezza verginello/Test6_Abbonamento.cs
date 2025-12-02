using NUnit.Framework;
using System;
using System.Collections.Generic;

public class Tests_Abbonamento
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }

    [Test] // Test Attributi
    public void TestAttributiAbbonamento()
    {
        Abbonamento abb = new Abbonamento();
        
        abb.Id = 15;
        Assert.That(abb.Id, Is.EqualTo(15));
        
        abb.Tipo = TipoAbbonamento.Premium;
        Assert.That(abb.Tipo, Is.EqualTo(TipoAbbonamento.Premium));
        
        DateTime dataInizioTest = new DateTime(2025, 1, 1);
        abb.DataInizio = dataInizioTest;
        Assert.That(abb.DataInizio, Is.EqualTo(dataInizioTest));
        
        DateTime dataScadenzaTest = new DateTime(2025, 12, 31);
        abb.DataScadenza = dataScadenzaTest;
        Assert.That(abb.DataScadenza, Is.EqualTo(dataScadenzaTest));
        
        abb.Prezzo = 99.99m;
        Assert.That(abb.Prezzo, Is.EqualTo(99.99m));
        
        abb.Stato = StatoAbbonamento.Attivo;
        Assert.That(abb.Stato, Is.EqualTo(StatoAbbonamento.Attivo));
        
        List<Pagamento> listaPagamenti = new List<Pagamento>();
        abb.Pagamenti = listaPagamenti;
        Assert.That(abb.Pagamenti, Is.EqualTo(listaPagamenti));
    }
    
    [Test] // Test Costruttore con parametri
    public void TestCostruttoreAbbonamento()
    {
        DateTime dataInizio = new DateTime(2025, 6, 1);
        DateTime dataScadenza = new DateTime(2025, 12, 1);
        
        Abbonamento abb = new Abbonamento(5, TipoAbbonamento.Base, dataInizio, dataScadenza, 50.00m);
        
        Assert.That(abb.Id, Is.EqualTo(5));
        Assert.That(abb.Tipo, Is.EqualTo(TipoAbbonamento.Base));
        Assert.That(abb.DataInizio, Is.EqualTo(dataInizio));
        Assert.That(abb.DataScadenza, Is.EqualTo(dataScadenza));
        Assert.That(abb.Prezzo, Is.EqualTo(50.00m));
        Assert.That(abb.Pagamenti, Is.Not.Null);
        Assert.That(abb.Pagamenti.Count, Is.EqualTo(0));
    }
    
    [Test] // Test Costruttore di default
    public void TestCostruttoreDefaultAbbonamento()
    {
        Abbonamento abb = new Abbonamento();
        
        Assert.That(abb.Id, Is.EqualTo(0));
        Assert.That(abb.Tipo, Is.EqualTo(TipoAbbonamento.VIP));
        Assert.That(abb.DataInizio, Is.EqualTo(DateTime.Now).Within(5000).Milliseconds);
        Assert.That(abb.DataScadenza, Is.Null);
        Assert.That(abb.Prezzo, Is.EqualTo(0.00m));
        Assert.That(abb.Pagamenti, Is.Not.Null);
    }
    
    [Test] // Test IsScaduto - non scaduto
    public void TestIsScadutoNonScaduto()
    {
        DateTime dataScadenza = DateTime.Now.AddMonths(3);
        Abbonamento abb = new Abbonamento(1, TipoAbbonamento.Base, DateTime.Now, dataScadenza, 30.00m);
        
        bool result = abb.IsScaduto();
        Assert.That(result, Is.False);
    }
    
    [Test] // Test IsScaduto - scaduto
    public void TestIsScadutoScaduto()
    {
        DateTime dataScadenza = DateTime.Now.AddDays(-10);
        Abbonamento abb = new Abbonamento(2, TipoAbbonamento.Premium, DateTime.Now.AddMonths(-6), dataScadenza, 60.00m);
        
        bool result = abb.IsScaduto();
        Assert.That(result, Is.True);
    }
    
    [Test] // Test IsScaduto - senza data scadenza
    public void TestIsScadutoSenzaDataScadenza()
    {
        Abbonamento abb = new Abbonamento(3, TipoAbbonamento.VIP, DateTime.Now, null, 120.00m);
        
        bool result = abb.IsScaduto();
        Assert.That(result, Is.False);
    }
    
    [Test] // Test CalcolaGiorniRimanenti - con giorni rimanenti
    public void TestCalcolaGiorniRimanentiConGiorni()
    {
        DateTime dataScadenza = DateTime.Now.AddDays(30);
        Abbonamento abb = new Abbonamento(4, TipoAbbonamento.Base, DateTime.Now, dataScadenza, 30.00m);
        
        int giorni = abb.CalcolaGiorniRimanenti();
        Assert.That(giorni, Is.EqualTo(30).Within(1)); // Within(1) per tolleranza
    }
    
    [Test] // Test CalcolaGiorniRimanenti - abbonamento scaduto
    public void TestCalcolaGiorniRimanentiScaduto()
    {
        DateTime dataScadenza = DateTime.Now.AddDays(-5);
        Abbonamento abb = new Abbonamento(5, TipoAbbonamento.Premium, DateTime.Now.AddMonths(-6), dataScadenza, 60.00m);
        
        int giorni = abb.CalcolaGiorniRimanenti();
        Assert.That(giorni, Is.EqualTo(0));
    }
    
    [Test] // Test CalcolaGiorniRimanenti - senza data scadenza
    public void TestCalcolaGiorniRimanentiSenzaData()
    {
        Abbonamento abb = new Abbonamento(6, TipoAbbonamento.VIP, DateTime.Now, null, 120.00m);
        
        int giorni = abb.CalcolaGiorniRimanenti();
        Assert.That(giorni, Is.EqualTo(0));
    }
    
    [Test] // Test Rinnova - abbonamento Base (3 mesi)
    public void TestRinnovaBase()
    {
        DateTime dataScadenza = new DateTime(2025, 10, 1);
        Abbonamento abb = new Abbonamento(7, TipoAbbonamento.Base, DateTime.Now, dataScadenza, 30.00m);
        
        abb.Rinnova();
        
        Assert.That(abb.DataInizio, Is.EqualTo(dataScadenza));
        Assert.That(abb.DataScadenza, Is.EqualTo(dataScadenza.AddMonths(3)));
    }
    
    [Test] // Test Rinnova - abbonamento Premium (6 mesi)
    public void TestRinnovaPremium()
    {
        DateTime dataScadenza = new DateTime(2025, 11, 15);
        Abbonamento abb = new Abbonamento(8, TipoAbbonamento.Premium, DateTime.Now, dataScadenza, 60.00m);
        
        abb.Rinnova();
        
        Assert.That(abb.DataInizio, Is.EqualTo(dataScadenza));
        Assert.That(abb.DataScadenza, Is.EqualTo(dataScadenza.AddMonths(6)));
    }
    
    [Test] // Test Rinnova - abbonamento VIP (1 anno)
    public void TestRinnovaVIP()
    {
        DateTime dataScadenza = new DateTime(2025, 12, 31);
        Abbonamento abb = new Abbonamento(9, TipoAbbonamento.VIP, DateTime.Now, dataScadenza, 120.00m);
        
        abb.Rinnova();
        
        Assert.That(abb.DataInizio, Is.EqualTo(dataScadenza));
        Assert.That(abb.DataScadenza, Is.EqualTo(dataScadenza.AddYears(1)));
    }
    
    [Test] // Test Rinnova - senza data scadenza
    public void TestRinnovaSenzaDataScadenza()
    {
        Abbonamento abb = new Abbonamento(10, TipoAbbonamento.Base, DateTime.Now, null, 30.00m);
        
        abb.Rinnova();
        
        Assert.That(abb.DataInizio, Is.EqualTo(DateTime.Now).Within(5000).Milliseconds);
        Assert.That(abb.DataScadenza, Is.EqualTo(DateTime.Now.AddMonths(3)).Within(5000).Milliseconds);
    }
    
    [Test] // Test ToString
    public void TestToString()
    {
        DateTime dataInizio = new DateTime(2025, 1, 1);
        DateTime dataScadenza = new DateTime(2025, 4, 1);
        Abbonamento abb = new Abbonamento(11, TipoAbbonamento.Base, dataInizio, dataScadenza, 45.50m);
        
        string result = abb.ToString();
        
        Assert.That(result, Does.Contain("Id: 11"));
        Assert.That(result, Does.Contain("Tipo: Base"));
        Assert.That(result, Does.Contain("01/01/2025"));
        Assert.That(result, Does.Contain("01/04/2025"));
        Assert.That(result, Does.Contain("45"));
    }
    
    [Test] // Test ToString senza data scadenza
    public void TestToStringSenzaDataScadenza()
    {
        Abbonamento abb = new Abbonamento(12, TipoAbbonamento.Premium, DateTime.Now, null, 60.00m);
        
        string result = abb.ToString();
        
        Assert.That(result, Does.Contain("Data Scadenza: Nessuna"));
    }
    
    [Test] // Test Lista Pagamenti
    public void TestListaPagamenti()
    {
        Abbonamento abb = new Abbonamento(13, TipoAbbonamento.VIP, DateTime.Now, DateTime.Now.AddYears(1), 120.00m);
        
        Assert.That(abb.Pagamenti.Count, Is.EqualTo(0));
        
        Pagamento p1 = new Pagamento(1, DateTime.Now, 120.00m, "Carta", true, abb);
        abb.Pagamenti.Add(p1);
        
        Assert.That(abb.Pagamenti.Count, Is.EqualTo(1));
        Assert.That(abb.Pagamenti[0], Is.EqualTo(p1));
    }
    
    [Test] // Test Stati Abbonamento
    public void TestStatiAbbonamento()
    {
        Abbonamento abb = new Abbonamento();
        
        abb.Stato = StatoAbbonamento.Non_Attivo;
        Assert.That(abb.Stato, Is.EqualTo(StatoAbbonamento.Non_Attivo));
        
        abb.Stato = StatoAbbonamento.Attivo;
        Assert.That(abb.Stato, Is.EqualTo(StatoAbbonamento.Attivo));
    }
    
    [Test] // Test Tutti i tipi di abbonamento
    public void TestTuttiTipiAbbonamento()
    {
        Abbonamento abb1 = new Abbonamento(14, TipoAbbonamento.Base, DateTime.Now, null, 30.00m);
        Assert.That(abb1.Tipo, Is.EqualTo(TipoAbbonamento.Base));
        
        Abbonamento abb2 = new Abbonamento(15, TipoAbbonamento.Premium, DateTime.Now, null, 60.00m);
        Assert.That(abb2.Tipo, Is.EqualTo(TipoAbbonamento.Premium));
        
        Abbonamento abb3 = new Abbonamento(16, TipoAbbonamento.VIP, DateTime.Now, null, 120.00m);
        Assert.That(abb3.Tipo, Is.EqualTo(TipoAbbonamento.VIP));
    }
}
 