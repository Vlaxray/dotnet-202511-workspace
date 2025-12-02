using System.Reflection.PortableExecutable;
using NUnit.Framework;


public class Test7_PartecipazioneCorso
{
    [SetUp]
    public void Setup()
    {
        // Codice da eseguire prima di ogni test
    }
    [Test]//Test Attributi
    public void TestAttributiPartecipazioneCorso()
    {
        PartecipazioneCorso pc = new PartecipazioneCorso();
        pc.Id = 62;
        Assert.That(pc.Id, Is.EqualTo(62));

        DateTime dataTest = new DateTime(2025, 11, 29);
        pc.Data = dataTest;
        Assert.That(pc.Data, Is.EqualTo(dataTest));

        pc.Presente = true;
        Assert.That(pc.Presente, Is.True);
        pc.Presente = false;
        Assert.That(pc.Presente, Is.False);

        var membro = new Membro { };
        pc.Membro = membro;
        Assert.That(pc.Membro, Is.EqualTo(membro));
        var corso = new Corso { };
        pc.Corso = corso;
        Assert.That(pc.Corso, Is.EqualTo(corso));
    }
    [Test]
    public void VerificaFrequenza_RitornaValoreCorretto()
    {
        // Crea l'oggetto partecipazione
        PartecipazioneCorso partecipazione = new PartecipazioneCorso();

        decimal frequenza = partecipazione.VerificaFrequenza();

        // Verifica il risultato (2024 / 12 = 168.666...)
        Assert.That(frequenza, Is.EqualTo(0m).Within(0.001m));
    }
    [Test]
    public void RegistraPresenza_ConMembroEcorsoNull_LanciaInvalidOperationException()
    {
        // Arrange
        var partecipazione = new PartecipazioneCorso
        {
            Presente = true
            // _membro e _corso non inizializzati
        };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => partecipazione.RegistraPresenza());
    }

    [Test]
    public void RegistraPresenza_ConDatiValidi_NonLanciaEccezione()
    {   
        PartecipazioneCorso par = new PartecipazioneCorso(1, DateTime.Now, true, new Corso(), new Membro());
        var membro = new Membro { Id = 1, Name = "Mario" };
        var corso = new Corso { Id = 1, Orario = "09:00" };
        var partecipazione = new PartecipazioneCorso
        {
            Membro = membro,
            Corso = corso,
            Presente = true
        };

        // Act & Assert
        Assert.DoesNotThrow(() => partecipazione.RegistraPresenza());
    }

    [Test]
    public void RegistraPresenza_ConPresenteFalse_NonStampaMessaggio()
    {
        // Arrange
        var membro = new Membro { Id = 1, Name = "Mario" };
        var corso = new Corso { Id = 1, Orario = "09:00" };
        var partecipazione = new PartecipazioneCorso
        {
            Membro = membro,
            Corso = corso,
            Presente = false
        };

        // Act & Assert
        Assert.DoesNotThrow(() => partecipazione.RegistraPresenza());
        // Non si può verificare Console.WriteLine direttamente con NUnit senza redirect
    }
}

