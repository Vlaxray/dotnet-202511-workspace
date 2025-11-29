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

}

