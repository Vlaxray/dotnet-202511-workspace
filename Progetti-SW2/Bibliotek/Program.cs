using System;

namespace BibliotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creo alcuni libri
            Libro libro1 = new Libro("978-1234567890", "Il Signore degli Anelli", "J.R.R. Tolkien", 1954, Libro.Stato.Disponibile);
            Libro libro2 = new Libro("978-0987654321", "1984", "George Orwell", 1949, Libro.Stato.Disponibile);

            // Creo un utente
            Utente utente = new Utente("001", "Giorgio", "Rossi", "giorgiorossi@giorgio.com", "n° 0123456789");

            Console.WriteLine("Dati utente:");
            Console.WriteLine(utente);
            Console.WriteLine(new string('-', 50));

            // Prenotazione libro
            utente.PrenotaLibro(libro1);
            Console.WriteLine($"Stato del libro prenotato: {libro1.stato}");
            Console.WriteLine(new string('-', 50));

            // Provo a prenotare un altro libro (non deve permettere)
            utente.PrenotaLibro(libro2);

            // Prendere il libro
            utente.PrendiLibro();
            Console.WriteLine($"Stato del libro dopo il prestito: {libro1.stato}");
            Console.WriteLine(new string('-', 50));

            // Annullare prenotazione (non c'è più, dovrebbe avvisare)
            utente.AnnullaPrenotaLibro();

            // Impostare scadenza prestito su un libro nuovo
            Prenotazione prenotazione = new Prenotazione(1, DateTime.Now, DateTime.Now, Prenotazione.Prenotazione_Stato.Attiva);
            prenotazione.ImpostaScadenzaPrestito();
            Console.WriteLine($"Data scadenza prestito tra 3 giorni: {prenotazione.Data_Scadenza}");
        }
    }

    public class Libro
    {
        public string Isbn { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int Anno_Pubblicazione { get; set; }
        public Stato stato { get; set; }

        public enum Stato
        {
            Disponibile,
            Prenotata,
            InPrestito
        }

        public Libro(string isbn, string titolo, string autore, int anno_pubblicazione, Stato Stato)
        {
            this.Isbn = isbn;
            this.Titolo = titolo;
            this.Autore = autore;
            this.Anno_Pubblicazione = anno_pubblicazione;
            this.stato = Stato;
        }

        public override string ToString()
        {
            return $"{Isbn} - {Titolo} - {Autore} - {Anno_Pubblicazione} - {stato}";
        }
    }

    public class Utente
    {
        public string Uuid { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string NumeroDiTessera { get; set; }

        public Libro LibroPrenotato { get; private set; }

        public Utente(string uuid, string nome, string cognome, string email, string numeroDiTessera)
        {
            Uuid = uuid;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            NumeroDiTessera = numeroDiTessera;
        }

        public Utente() : this("001", "Giorgio", "Rossi", "giorgiorossi@giorgio.com", "n° 0123456789") { }

        public void PrenotaLibro(Libro libro)
        {
            if (LibroPrenotato == null)
            {
                LibroPrenotato = libro;
                libro.stato = Libro.Stato.Prenotata;
                Console.WriteLine($"Hai prenotato il libro: {libro.Titolo}");
            }
            else
            {
                Console.WriteLine("Hai già un libro prenotato.");
            }
        }

        public void PrendiLibro()
        {
            if (LibroPrenotato != null)
            {
                Console.WriteLine($"Hai preso il libro: {LibroPrenotato.Titolo}");
                LibroPrenotato.stato = Libro.Stato.InPrestito;
                LibroPrenotato = null;
            }
            else
            {
                Console.WriteLine("Non hai prenotato nessun libro.");
            }
        }

        public void AnnullaPrenotaLibro()
        {
            if (LibroPrenotato != null)
            {
                Console.WriteLine($"Prenotazione annullata per il libro: {LibroPrenotato.Titolo}");
                LibroPrenotato.stato = Libro.Stato.Disponibile;
                LibroPrenotato = null;
            }
            else
            {
                Console.WriteLine("Non hai prenotazioni attive.");
            }
        }

        public override string ToString()
        {
            return $"Uuid: {Uuid}, Nome: {Nome}, Cognome: {Cognome}, Email: {Email}, Numero di tessera: {NumeroDiTessera}";
        }
    }

    public class Prenotazione
    {
        public int Codice_Prenotazione { get; set; }
        public DateTime Data_Prenotazione { get; set; }
        public DateTime Data_Scadenza { get; set; }
        public Prenotazione_Stato Stato { get; set; }

        public enum Prenotazione_Stato
        {
            Attiva,
            Annullata,
            Completata
        }

        public Prenotazione(int codice, DateTime dataPrenotazione, DateTime dataScadenza, Prenotazione_Stato stato)
        {
            Codice_Prenotazione = codice;
            Data_Prenotazione = dataPrenotazione;
            Data_Scadenza = dataScadenza;
            Stato = stato;
        }

        public void ImpostaScadenzaPrestito()
        {
            Data_Scadenza = DateTime.Now.AddDays(3);
        }
    }
}
