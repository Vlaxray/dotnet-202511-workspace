using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ======================
        // Creazione palestra
        // ======================
        Palestra palestra = new Palestra(
            nome: "Palestra Dei Forti",
            indirizzo: "Via dei Fortificanti 10",
            telefono: "+391234567890",
            capienzaMassima: 10,
            istruttori: new List<Istruttore>()
        );

        // ======================
        // Creazione istruttori
        // ======================
        Istruttore istr1 = new Istruttore(
            id: 1,
            nome: "Marco",
            cognome: "Rossi",
            specializzazione: "Forza",
            dataAssunzione: DateTime.Now.AddYears(-3),
            corso: null,
            palestra: palestra
        );

        Istruttore istr2 = new Istruttore(
            id: 2,
            nome: "Luca",
            cognome: "Bianchi",
            specializzazione: "Cardio",
            dataAssunzione: DateTime.Now.AddYears(-1),
            corso: null,
            palestra: palestra
        );

        palestra.Istruttori.Add(istr1);
        palestra.Istruttori.Add(istr2);

        // ======================
        // Creazione corsi
        // ======================
        Corso corso1 = new Corso(1, "Powerlifting", "Corso avanzato di sollevamento pesi", "18:00-19:30", 90, 5);
        Corso corso2 = new Corso(2, "Cardio Blast", "Allenamento cardio intenso", "19:00-20:00", 60, 8);

        // Assegna corsi agli istruttori
        istr1.Corsi.Add(corso1);
        istr2.Corsi.Add(corso2);

        // ======================
        // Creazione membri
        // ======================
        Membro membro1 = new Membro(1, "Alice", "Verdi", "alice@email.com", "3331234567", DateTime.Now.AddMonths(-2), new DateTime(1995, 5, 12));
        Membro membro2 = new Membro(2, "Bob", "Neri", "bob@email.com", "3339876543", DateTime.Now.AddMonths(-1), new DateTime(1988, 2, 23));
        Membro membro3 = new Membro(3, "Carla", "Gialli", "carla@email.com", "3335678901", DateTime.Now.AddDays(-15), new DateTime(2000, 10, 5));

        // ======================
        // Creazione abbonamenti
        // ======================
        Abbonamento abb1 = new Abbonamento(1, TipoAbbonamento.Premium, DateTime.Now.AddMonths(-2), null, 200m);
        Abbonamento abb2 = new Abbonamento(2, TipoAbbonamento.Base, DateTime.Now.AddMonths(-1), null, 120m);

        membro1.Abbonamento = abb1;
        membro2.Abbonamento = abb2;
        membro3.Abbonamento = new Abbonamento();

        palestra.Abbonamenti.Add(abb1);
        palestra.Abbonamenti.Add(abb2);
        palestra.Abbonamenti.Add(membro3.Abbonamento);

        // ======================
        // Iscrizione membri ai corsi
        // ======================
        corso1.AggiungiPartecipante(new PartecipazioneCorso(1, DateTime.Now, false, corso1, membro1));
        corso1.AggiungiPartecipante(new PartecipazioneCorso(2, DateTime.Now, false, corso1, membro2));

        corso2.AggiungiPartecipante(new PartecipazioneCorso(3, DateTime.Now, false, corso2, membro2));
        corso2.AggiungiPartecipante(new PartecipazioneCorso(4, DateTime.Now, false, corso2, membro3));

        // ======================
        // Creazione esercizi e schede allenamento
        // ======================
        Esercizio es1 = new Esercizio(1, "Squat", "Squat con bilanciere", 4, 12, 90, "Bilanciere");
        Esercizio es2 = new Esercizio(2, "Panca piana", "Panca con bilanciere", 3, 10, 120, "Bilanciere");

        SchedaAllenamento scheda1 = new SchedaAllenamento();
        scheda1.Esercizi.Add(es1);
        scheda1.Esercizi.Add(es2);

        membro1.SchedaAllenamento = scheda1;

        // ======================
        // Visualizzazione dati
        // ======================
        Console.WriteLine("=== Palestra ===");
        Console.WriteLine(palestra);

        Console.WriteLine("\n=== Istruttori ===");
        foreach (var istr in palestra.Istruttori)
            Console.WriteLine(istr);

        Console.WriteLine("\n=== Corsi e partecipanti ===");
        foreach (var istr in palestra.Istruttori)
        {
            foreach (var corso in istr.Corsi)
            {
                Console.WriteLine(corso);
            }
        }

        Console.WriteLine("\n=== Membri ===");
        Console.WriteLine(membro1);
        Console.WriteLine(membro2);
        Console.WriteLine(membro3);

        Console.WriteLine("\n=== Report Mensile Palestra ===");
        Console.WriteLine(palestra.GeneraReportMensile());

        Console.WriteLine("\n=== Notifiche ===");
        Notifica notifica = new Notifica();
        notifica.Messaggio = "Promemoria iscrizione corso";
        notifica.InviaPromemoriaCorso();
        notifica.SegnaComeLetta();

        Console.WriteLine("\n=== Fine demo palestra ===");
    }
}
