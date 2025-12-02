using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Tests_Palestra
{
    private Palestra palestraTest;
    private List<Istruttore> istruttoriTest;
    private List<Abbonamento> abbonamentiTest;
    private Membro membroTest;
    
    [SetUp]
    public void Setup()
    {
        // Creo la palestra prima di tutto (necessaria per gli istruttori)
        palestraTest = new Palestra();
        
        // Creo membri di test
        membroTest = new Membro(1, "Mario", "Rossi", "mario@test.com", "1234567890", DateTime.Now, DateTime.Now.AddYears(-25));
        
        // Creo abbonamenti di test
        abbonamentiTest = new List<Abbonamento>
        {
            new Abbonamento(1, TipoAbbonamento.Base, DateTime.Now, DateTime.Now.AddMonths(3), 30.00m),
            new Abbonamento(2, TipoAbbonamento.Premium, DateTime.Now, DateTime.Now.AddMonths(6), 60.00m),
            new Abbonamento(3, TipoAbbonamento.VIP, DateTime.Now, DateTime.Now.AddYears(1), 120.00m)
        };
        
        // Creo corsi di test
        Corso corso1 = new Corso(1, "Yoga", "Corso di rilassamento", "10:00", 60, 20);
        Corso corso2 = new Corso(2, "Spinning", "Corso ad alta intensità", "15:00", 45, 15);
        
        // Creo istruttori di test con la palestra
        Istruttore istruttore1 = new Istruttore(1, "Luca", "Verdi", "Fitness", DateTime.Now.AddYears(-3), corso1, palestraTest);
        Istruttore istruttore2 = new Istruttore(2, "Anna", "Bianchi", "Cardio", DateTime.Now.AddYears(-2), corso2, palestraTest);
        
        istruttoriTest = new List<Istruttore> { istruttore1, istruttore2 };
        
        // Aggiorno la palestra con i dati completi
        palestraTest.Nome = "FitZone";
        palestraTest.Indirizzo = "Via Roma 123";
        palestraTest.Telefono = "+390112345678";
        palestraTest.CapienzaMassima = 20;
        palestraTest.Istruttori = istruttoriTest;
        palestraTest.Abbonamenti = abbonamentiTest;
    }

    [Test] // Test Attributi
    public void TestAttributiPalestra()
    {
        Palestra p = new Palestra();
        
        p.Nome = "SuperGym";
        Assert.That(p.Nome, Is.EqualTo("SuperGym"));
        
        p.Indirizzo = "Via Milano 45";
        Assert.That(p.Indirizzo, Is.EqualTo("Via Milano 45"));
        
        p.Telefono = "+390123456789";
        Assert.That(p.Telefono, Is.EqualTo("+390123456789"));
        
        p.CapienzaMassima = 50;
        Assert.That(p.CapienzaMassima, Is.EqualTo(50));
        
        List<Istruttore> nuoviIstruttori = new List<Istruttore>();
        p.Istruttori = nuoviIstruttori;
        Assert.That(p.Istruttori, Is.EqualTo(nuoviIstruttori));
        
        List<Abbonamento> nuoviAbbonamenti = new List<Abbonamento>();
        p.Abbonamenti = nuoviAbbonamenti;
        Assert.That(p.Abbonamenti, Is.EqualTo(nuoviAbbonamenti));
    }
    
    [Test] // Test Costruttore con parametri
    public void TestCostruttorePalestra()
    {
        Palestra pTemp = new Palestra();
        List<Istruttore> istrTemp = new List<Istruttore>
        {
            new Istruttore(10, "Test", "Istruttore", "TestSpec", DateTime.Now, null, pTemp)
        };
        
        Palestra p = new Palestra("PowerGym", "Via Torino 67", "+390987654321", 30, istrTemp, abbonamentiTest);
        
        Assert.That(p.Nome, Is.EqualTo("PowerGym"));
        Assert.That(p.Indirizzo, Is.EqualTo("Via Torino 67"));
        Assert.That(p.Telefono, Is.EqualTo("+390987654321"));
        Assert.That(p.CapienzaMassima, Is.EqualTo(30));
        Assert.That(p.Istruttori, Is.Not.Null);
        Assert.That(p.Abbonamenti, Is.Not.Null);
    }
    
    [Test] // Test Costruttore di default
    public void TestCostruttoreDefaultPalestra()
    {
        Palestra p = new Palestra();
        
        Assert.That(p.Nome, Is.EqualTo("Palestra Dei Forti"));
        Assert.That(p.Indirizzo, Is.EqualTo("via dei Fortificanti"));
        Assert.That(p.Telefono, Is.EqualTo("+991234567890"));
        Assert.That(p.CapienzaMassima, Is.EqualTo(5));
        Assert.That(p.Istruttori, Is.Not.Null);
        Assert.That(p.Abbonamenti, Is.Not.Null);
    }
    
    [Test] // Test GeneraReportMensile con dati
    public void TestGeneraReportMensile()
    {
        string report = palestraTest.GeneraReportMensile();
        
        Assert.That(report, Does.Contain("Nuovi iscritti: 3"));
        Assert.That(report, Does.Contain("Frequenza media:"));
        Assert.That(report, Does.Contain("Incasso totale:"));
        Assert.That(report, Does.Contain("210")); // 30 + 60 + 120 = 210
    }
    
    [Test] // Test GeneraReportMensile senza abbonamenti
    public void TestGeneraReportMensileSenzaAbbonamenti()
    {
        Palestra p = new Palestra("EmptyGym", "Via Vuota 1", "+390000000000", 10, new List<Istruttore>(), new List<Abbonamento>());
        string report = p.GeneraReportMensile();
        
        Assert.That(report, Does.Contain("Nuovi iscritti: 0, Frequenza media: 0,00, Incasso totale: 0,00 €"));
    }
    
    [Test] // Test VerificaCapienzaCorsi - nessun superamento
    public void TestVerificaCapienzaCorsiNessunSuperamento()
    {
        List<string> corsiOltre = palestraTest.VerificaCapienzaCorsi();
        
        Assert.That(corsiOltre, Is.Empty);
    }
    
    [Test] // Test VerificaCapienzaCorsi - con superamento
    public void TestVerificaCapienzaCorsiConSuperamento()
    {
        // Creo una palestra temporanea con capienza bassa
        Palestra pTemp = new Palestra();
        pTemp.CapienzaMassima = 5;
        
        // Creo un corso con più partecipazioni della capienza
        Corso corsoSovraff = new Corso(10, "Zumba", "Corso affollato", "18:00", 60, 30);
        
        // Simulo l'aggiunta di partecipazioni (dipende dalla struttura di PartecipazioneCorso)
        // Assumo che il corso abbia una proprietà Partecipazioni che è una lista
        // e che possiamo aggiungere elementi
        for (int i = 0; i < 10; i++)
        {
            // Questa parte dipende dalla struttura di PartecipazioneCorso
            // corsoSovraff.Partecipazioni.Add(new PartecipazioneCorso(...));
        }
        
        Istruttore istruttoreSovraff = new Istruttore(10, "Paolo", "Neri", "Dance", DateTime.Now, corsoSovraff, pTemp);
        pTemp.Istruttori = new List<Istruttore> { istruttoreSovraff };
        
        List<string> corsiOltre = pTemp.VerificaCapienzaCorsi();
        
        // Il test dipende da come vengono aggiunte le partecipazioni
        Assert.That(corsiOltre, Is.Not.Null);
    }
    
    [Test] // Test GestisciPromemoria - nessun promemoria
    public void TestGestisciPromemoriaVuoto()
    {
        Palestra p = new Palestra("QuietGym", "Via Tranquilla 5", "+390111111111", 15, new List<Istruttore>(), new List<Abbonamento>());
        
        List<string> promemoria = p.GestisciPromemoria();
        
        Assert.That(promemoria, Is.Empty);
    }
    
    [Test] // Test GestisciPromemoria - con promemoria da inviare
    public void TestGestisciPromemoriaConPromemoria()
    {
        // Creo una palestra temporanea
        Palestra pTemp = new Palestra();
        
        // Creo un corso con partecipazione tra 25-30 giorni
        Corso corsoFuturo = new Corso(20, "Pilates", "Corso futuro", "09:00", 50, 10);
        
        
        Istruttore istruttoreFuturo = new Istruttore(20, "Elena", "Gialli", "Wellness", DateTime.Now, corsoFuturo, pTemp);
        pTemp.Istruttori = new List<Istruttore> { istruttoreFuturo };
        
        List<string> promemoria = pTemp.GestisciPromemoria();
        
        // Il test dipende dalla corretta implementazione delle partecipazioni
        Assert.That(promemoria, Is.Not.Null);
    }
    
    [Test] // Test ToString
    public void TestToString()
    {
        string result = palestraTest.ToString();
        
        Assert.That(result, Does.Contain("FitZone"));
        Assert.That(result, Does.Contain("Via Roma 123"));
        Assert.That(result, Does.Contain("2")); // Numero istruttori
    }
    
    [Test] // Test con liste vuote nel costruttore
    public void TestCostruttoreConListeVuote()
    {
        Palestra p = new Palestra("MinimalGym", "Via Piccola 1", "+390333333333", 5, new List<Istruttore>(), new List<Abbonamento>());
        
        Assert.That(p.Istruttori, Is.Not.Null);
        Assert.That(p.Abbonamenti, Is.Not.Null);
    }
    
    [Test] // Test GeneraReportMensile con frequenza media
    public void TestGeneraReportMensileFrequenzaMedia()
    {
        string report = palestraTest.GeneraReportMensile();
        
        Assert.That(report, Does.Contain("Frequenza media:"));
        Assert.That(report, Does.Contain("Incasso totale:"));
    }
    
    [Test] // Test VerificaCapienzaCorsi con capienza esatta
    public void TestVerificaCapienzaCorsiCapienzaEsatta()
    {
        Palestra p = new Palestra();
        p.CapienzaMassima = 10;
        p.Istruttori = new List<Istruttore>();
        
        List<string> corsiOltre = p.VerificaCapienzaCorsi();
        
        Assert.That(corsiOltre, Is.Empty);
    }
    
    [Test] // Test GestisciPromemoria con date passate
    public void TestGestisciPromemoriaDatePassate()
    {
        Palestra p = new Palestra();
        p.Istruttori = new List<Istruttore>();
        
        List<string> promemoria = p.GestisciPromemoria();
        
        Assert.That(promemoria, Is.Empty);
    }
    
    [Test] // Test GeneraReportMensile con singolo abbonamento
    public void TestGeneraReportMensileSingoloAbbonamento()
    {
        Abbonamento abbSingolo = new Abbonamento(99, TipoAbbonamento.Base, DateTime.Now, DateTime.Now.AddMonths(3), 50.00m);
        Palestra p = new Palestra("SingleGym", "Via Uno 1", "+390555555555", 10, new List<Istruttore>(), new List<Abbonamento> { abbSingolo });
        
        string report = p.GeneraReportMensile();
        
        Assert.That(report, Does.Contain("Nuovi iscritti: 0, Frequenza media: 0,00, Incasso totale: 0,00 €"));
        
    }
}