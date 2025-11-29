using NUnit.Framework;


public class Tests_Pagamento
{
    private Abbonamento abbonamentoTest;
    
    [SetUp]
    public void Setup()
    {
        // Creo un abbonamento di test da usare nei vari test
        abbonamentoTest = new Abbonamento(1, TipoAbbonamento.Base, DateTime.Now, null, 50.00m);
    }

    [Test] // Test Attributi
    public void TestAttributiPagamento()
    {
        Pagamento p = new Pagamento();
        p.Id = 10;
        Assert.That(p.Id, Is.EqualTo(10));
        
        DateTime dataTest = new DateTime(2025, 11, 29);
        p.Data = dataTest;
        Assert.That(p.Data, Is.EqualTo(dataTest));
        
        p.Importo = 99.99m;
        Assert.That(p.Importo, Is.EqualTo(99.99m));
        
        p.MetodoPagamento = "Carta di credito";
        Assert.That(p.MetodoPagamento, Is.EqualTo("Carta di credito"));
        
        p.Pagato = true;
        Assert.That(p.Pagato, Is.True);
        p.Pagato = false;
        Assert.That(p.Pagato, Is.False);
        
        p.Abbonamento = abbonamentoTest;
        Assert.That(p.Abbonamento, Is.EqualTo(abbonamentoTest));
    }
    
    [Test] // Test Costruttore con parametri
    public void TestCostruttorePagamento()
    {
        DateTime dataTest = new DateTime(2025, 10, 15);
        Pagamento p = new Pagamento(5, dataTest, 75.50m, "Bonifico", false, abbonamentoTest);
        
        Assert.That(p.Id, Is.EqualTo(5));
        Assert.That(p.Data, Is.EqualTo(dataTest));
        Assert.That(p.Importo, Is.EqualTo(75.50m));
        Assert.That(p.MetodoPagamento, Is.EqualTo("Bonifico"));
        Assert.That(p.Pagato, Is.False);
        Assert.That(p.Abbonamento, Is.EqualTo(abbonamentoTest));
    }
    
    [Test] // Test Costruttore di default
    public void TestCostruttoreDefaultPagamento()
    {
        Pagamento p = new Pagamento();
        
        Assert.That(p.Id, Is.EqualTo(0));
        Assert.That(p.Data, Is.EqualTo(DateTime.Now).Within(5000).Milliseconds);
        Assert.That(p.Importo, Is.EqualTo(0.0m));
        Assert.That(p.MetodoPagamento, Is.EqualTo(""));
        Assert.That(p.Pagato, Is.False);
    }
    
    [Test] // Test EseguiPagamento
    public void TestEseguiPagamento()
    {
        Pagamento p = new Pagamento(1, DateTime.Now, 50.00m, "Contanti", false, abbonamentoTest);
        
        Assert.That(p.Pagato, Is.False);
        p.EseguiPagamento();
        
        Assert.That(p.Pagato, Is.True);
        Assert.That(p.Data, Is.EqualTo(DateTime.Now).Within(5000).Milliseconds);
        Assert.That(abbonamentoTest.DataScadenza, Is.Not.Null);
    }
    
    [Test] // Test EseguiPagamento già eseguito
    public void TestEseguiPagamentoGiaEseguito()
    {
        Pagamento p = new Pagamento(2, DateTime.Now, 50.00m, "PayPal", true, abbonamentoTest);
        
        Assert.That(p.Pagato, Is.True);
        p.EseguiPagamento(); // Non dovrebbe cambiare nulla
        Assert.That(p.Pagato, Is.True);
    }
    
    [Test] // Test EseguiPagamento senza abbonamento
    public void TestEseguiPagamentoSenzaAbbonamento()
    {
        Pagamento p = new Pagamento(3, DateTime.Now, 50.00m, "Carta", false, null);
        
        Assert.Throws<InvalidOperationException>(() => p.EseguiPagamento());
    }
    
    [Test] // Test VerificaScadenzaPagamento - non scaduto
    public void TestVerificaScadenzaPagamentoNonScaduto()
    {
        Pagamento p = new Pagamento(4, DateTime.Now, 30.00m, "Contanti", false, abbonamentoTest);
        
        bool result = p.VerificaScadenzaPagamento();
        Assert.That(result, Is.False);
    }
    
    [Test] // Test VerificaScadenzaPagamento - scaduto
    public void TestVerificaScadenzaPagamentoScaduto()
    {
        DateTime dataVecchia = DateTime.Now.AddDays(-35);
        Pagamento p = new Pagamento(5, dataVecchia, 40.00m, "Bonifico", false, abbonamentoTest);
        
        bool result = p.VerificaScadenzaPagamento();
        Assert.That(result, Is.True);
    }
    
    [Test] // Test VerificaScadenzaPagamento - già pagato
    public void TestVerificaScadenzaPagamentoPagato()
    {
        DateTime dataVecchia = DateTime.Now.AddDays(-35);
        Pagamento p = new Pagamento(6, dataVecchia, 40.00m, "Carta", true, abbonamentoTest);
        
        bool result = p.VerificaScadenzaPagamento();
        Assert.That(result, Is.False); // Un pagamento eseguito non può essere scaduto
    }
    
    [Test] // Test GeneraRicevuta
    public void TestGeneraRicevuta()
    {
        Pagamento p = new Pagamento(7, DateTime.Now, 60.00m, "PayPal", true, abbonamentoTest);
        
        string ricevuta = p.GeneraRicevuta();
        
        Assert.That(ricevuta, Does.Contain("ID Pagamento: 7"));
        Assert.That(ricevuta, Does.Contain("60"));
        Assert.That(ricevuta, Does.Contain("PayPal"));
        Assert.That(ricevuta, Does.Contain("ESEGUITO"));
    }
    
    [Test] // Test ToString
    public void TestToString()
    {
        Pagamento p = new Pagamento(8, DateTime.Now, 45.00m, "Contanti", false, abbonamentoTest);
        
        string result = p.ToString();
        
        Assert.That(result, Does.Contain("Pagamento #8"));
        Assert.That(result, Does.Contain("45"));
        Assert.That(result, Does.Contain("Contanti"));
        Assert.That(result, Does.Contain("In sospeso"));
    }
    
    [Test] // Test Property Abbonamento con valore nullo
    public void TestAbbonamentoNullo()
    {
        Pagamento p = new Pagamento();
        
        Assert.Throws<ArgumentNullException>(() => p.Abbonamento = null);
    }
    
    [Test] // Test Metodi con diversi tipi di abbonamento
    public void TestPagamentoConDiversiTipiAbbonamento()
    {
        // Test con abbonamento Base (3 mesi)
        Abbonamento abbBase = new Abbonamento(1, TipoAbbonamento.Base, DateTime.Now, null, 30.00m);
        Pagamento p1 = new Pagamento(10, DateTime.Now, 30.00m, "Carta", false, abbBase);
        p1.EseguiPagamento();
        Assert.That(abbBase.DataScadenza, Is.EqualTo(DateTime.Now.AddMonths(3)).Within(5000).Milliseconds);
        
        // Test con abbonamento Premium (6 mesi)
        Abbonamento abbPremium = new Abbonamento(2, TipoAbbonamento.Premium, DateTime.Now, null, 60.00m);
        Pagamento p2 = new Pagamento(11, DateTime.Now, 60.00m, "PayPal", false, abbPremium);
        p2.EseguiPagamento();
        Assert.That(abbPremium.DataScadenza, Is.EqualTo(DateTime.Now.AddMonths(6)).Within(5000).Milliseconds);
        
        // Test con abbonamento VIP (1 anno)
        Abbonamento abbVIP = new Abbonamento(3, TipoAbbonamento.VIP, DateTime.Now, null, 120.00m);
        Pagamento p3 = new Pagamento(12, DateTime.Now, 120.00m, "Bonifico", false, abbVIP);
        p3.EseguiPagamento();
        Assert.That(abbVIP.DataScadenza, Is.EqualTo(DateTime.Now.AddYears(1)).Within(5000).Milliseconds);
    }
}