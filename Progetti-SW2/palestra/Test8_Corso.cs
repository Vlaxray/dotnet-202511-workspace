using NUnit.Framework;

namespace TestPalestra
{
    [TestFixture]
    public class Testc1
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]

        public void Corso_Constructor_ImpostaProprietaCorrettamente()
        {
            var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);

            Assert.That(c1.Id, Is.EqualTo(1));
            Assert.That(c1.Nome, Is.EqualTo("Yoga"));
            Assert.That(c1.Descrizione, Is.EqualTo("Lezione di yoga"));
            Assert.That(c1.Orario, Is.EqualTo("10:00"));
            Assert.That(c1.DurataMinuti, Is.EqualTo(60));
            Assert.That(c1.MaxPartecipanti, Is.EqualTo(2));
            Assert.That(c1.PostiOccupati, Is.EqualTo(0));                // valore iniziale
            Assert.That(c1.Partecipazioni.Count, Is.EqualTo(0));}
        public void VerificaDisponibilita_DovrebbeRestituireTrueQuandoCiSonoPosti()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            Assert.That(c1.VerificaDisponibilita(), Is.True);
        }

        [Test]
        public void AggiungiPartecipante_DovrebbeAggiungereUnMembro()
        {
            var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var partecipazione = new PartecipazioneCorso
            {
                Membro = new Membro { Id = 1, Name = "Mario" }
            };

            var risultato = c1.AggiungiPartecipante(partecipazione);

            Assert.That(risultato, Is.True);
            Assert.That(c1.PostiOccupati, Is.EqualTo(1));
        }

        [Test]
        public void AggiungiPartecipante_DovrebbeBloccareIscrizioneQuandoPieno()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var p1 = new PartecipazioneCorso { Membro = new Membro { Id = 1, Name = "Mario" } };
            var p2 = new PartecipazioneCorso { Membro = new Membro { Id = 2, Name = "Luca" } };
            var p3 = new PartecipazioneCorso { Membro = new Membro { Id = 3, Name = "Anna" } };

            c1.AggiungiPartecipante(p1);
            c1.AggiungiPartecipante(p2);
            var risultato = c1.AggiungiPartecipante(p3);

            Assert.That(risultato, Is.False);
            Assert.That(c1.PostiOccupati, Is.EqualTo(2));
        }

        [Test]
        public void AggiungiPartecipante_NonDovrebbeAggiungereLoStessoMembroDueVolte()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var partecipazione1 = new PartecipazioneCorso { Membro = new Membro { Id = 1, Name = "Mario" } };
            var partecipazione2 = new PartecipazioneCorso { Membro = new Membro { Id = 1, Name = "Mario" } };

            c1.AggiungiPartecipante(partecipazione1);
            var risultato = c1.AggiungiPartecipante(partecipazione2);

            Assert.That(risultato, Is.False);
            Assert.That(c1.Parte​cipazioni.Count, Is.EqualTo(1));
        }

        [Test]
        public void RimuoviPartecipante_DovrebbeRimuovereCorrettamente()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var partecipazione = new PartecipazioneCorso
            {
                Membro = new Membro { Id = 1, Name = "Mario" }
            };

            c1.AggiungiPartecipante(partecipazione);
            var risultato = c1.RimuoviPartecipante(partecipazione);

            Assert.That(risultato, Is.True);
            Assert.That(c1.PostiOccupati, Is.EqualTo(0));
        }

        [Test]
        public void RimuoviPartecipantePerMembro_DovrebbeRimuovereIlMembro()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var partecipazione = new PartecipazioneCorso
            {
                Membro = new Membro { Id = 1, Name = "Mario" }
            };

            c1.AggiungiPartecipante(partecipazione);

            var risultato = c1.RimuoviPartecipantePerMembro(partecipazione.Membro);

            Assert.That(risultato, Is.True);
            Assert.That(c1.Parte​cipazioni.Count, Is.EqualTo(0));
        }

        [Test]
        public void RimuoviPartecipantePerMembro_DovrebbeFallireSeNonIscritto()
        {   var c1 = new Corso(1, "Yoga", "Lezione di yoga", "10:00", 60, 2);
            var membro = new Membro { Id = 10, Name = "Giovanni" };

            var risultato = c1.RimuoviPartecipantePerMembro(membro);

            Assert.That(risultato, Is.False);
        }
    }
}
