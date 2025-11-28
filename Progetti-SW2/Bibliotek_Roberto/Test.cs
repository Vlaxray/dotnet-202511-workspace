using NUnit.Framework;


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Codice da eseguire prima di ogni test
        }

        [Test]
        public void TestPrenotazione()
        {
            Prenotazione prenotazione= new Prenotazione();

            Assert.That(prenotazione.StatoPrenotazione, Is.EqualTo(StatoPrenotazione.ATTIVA));

            prenotazione.StatoPrenotazione = StatoPrenotazione.ANNULLATA;
            Assert.That(prenotazione.StatoPrenotazione, Is.EqualTo(StatoPrenotazione.ANNULLATA));

            prenotazione.StatoPrenotazione = StatoPrenotazione.COMPLETATA;
            Assert.That(prenotazione.StatoPrenotazione, Is.EqualTo(StatoPrenotazione.COMPLETATA));


            string ris = DateTime.Now.Date.ToString().Substring(0 , 10);

            Assert.That(prenotazione.DataPrenotazione.Date.ToString().Substring(0,10), 
                        Is.EqualTo(ris));


            prenotazione.AggiungiPrenotazioneLibro(new Libro());  // 1 
            Assert.That(prenotazione.AggiungiPrenotazioneLibro(new Libro()), Is.EqualTo(true)); // 1
            
            Assert.That(prenotazione.Libri.Count, Is.EqualTo(2));
            Assert.That(prenotazione.Libri.Count, Is.Not.EqualTo(prenotazione.Libri.Count +1 )); // no

        }


        [Test]
        public void TestLibro()
        {
            Libro libro1= new Libro();
            libro1.Isbn = "Isbn-77";
            libro1.AnnoPubblicazione = 300;
            Assert.That(libro1.Isbn, Is.EqualTo("Isbn-77"));
            
            System.Console.WriteLine("ANNO TROVATO ---> " + libro1.AnnoPubblicazione);
            Assert.That(libro1.AnnoPubblicazione, Is.EqualTo(1800));


            libro1.Titolo = "titolo";
            libro1.Autore ="autore";

            Assert.That(libro1.Titolo, Is.EqualTo("titolo"));
            Assert.That(libro1.Autore, Is.EqualTo("autore"));

            System.Console.WriteLine("testing costruttore con parametri");

            Libro libro2= new Libro("isbn" , "mytitle" , "auth" , 2000 );
            Assert.That(libro2.Titolo, Is.EqualTo("mytitle"));
            Assert.That(libro2.Isbn, Is.EqualTo("isbn"));
            Assert.That(libro2.Autore, Is.EqualTo("auth"));
            Assert.That(libro2.AnnoPubblicazione, Is.EqualTo(2000));

            //test sulla Enum!!!
            Assert.That(libro2.StatoLibro, Is.EqualTo(StatoLibro.DISPONIBILE));
            
            libro2.StatoLibro = StatoLibro.NON_DISPONIBILE;
            Assert.That(libro2.StatoLibro, Is.EqualTo(StatoLibro.NON_DISPONIBILE));

            libro2.StatoLibro = StatoLibro.IN_PRESTITO;
            Assert.That(libro2.StatoLibro, Is.EqualTo(StatoLibro.IN_PRESTITO));
        
        }




    }

