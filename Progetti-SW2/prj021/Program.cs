using System;

        // Creazione lettere
        Lettera l1 = new Lettera("Mario", "Luca");                         // priorità 0
        LetteraPrioritaria l2 = new LetteraPrioritaria("Anna", "Paolo", 3);
        LetteraPrioritaria l3 = new LetteraPrioritaria("Gianni", "Marco", 0);
        LetteraPrioritaria l4 = new LetteraPrioritaria("Sara", "Dario", 1);

        // Creazione centrale
        CentraleSmistaPosta centrale = new CentraleSmistaPosta("CENT01");

        // Ricezione lettere
        centrale.RiceviLettera(l1);
        centrale.RiceviLettera(l2);
        centrale.RiceviLettera(l3);
        centrale.RiceviLettera(l4);

        // Smistamento (in blocco, come da tua implementazione)
        centrale.SmistaLettera();

        // Stampa finale dello stato delle lettere
        Console.WriteLine();
        Console.WriteLine("=== Stato finale lettere ===");
        Console.WriteLine(l1);
        Console.WriteLine(l2);
        Console.WriteLine(l3);
        Console.WriteLine(l4);
    

