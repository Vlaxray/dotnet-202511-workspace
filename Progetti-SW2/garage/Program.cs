using System;
using System.Linq;

class Program
{
    static Garage garage = new Garage();

    static void Main()
    {
        // Inserimento iniziale di alcuni veicoli
        VeicoloAMotore automobile1 = new Automobile(3, "Fiat", "Panda", 1987, "Diesel", 1200);
        VeicoloAMotore automobile2 = new Automobile(3, "Fiat", "Panda", 2022, "Benzina", 1400);
        VeicoloAMotore motocicletta1 = new Motocicletta("Ducati", "Panigale V4", 2022, "Benzina", 1149);
        VeicoloAMotore furgone1 = new Furgone(2000, "Iveco", "Ducato", 1990, "GPL", 2000);

        garage.ImmettiNuovoVeicolo(automobile1);
        garage.ImmettiNuovoVeicolo(automobile2);
        garage.ImmettiNuovoVeicolo(motocicletta1);
        garage.ImmettiNuovoVeicolo(furgone1);

        Menu(); // Avvio del menu
    }

    static void Menu()
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- Menu Gestione Garage ---");
            Console.WriteLine("1) Inserire un nuovo veicolo");
            Console.WriteLine("2) Estrarre un veicolo");
            Console.WriteLine("3) Stampare i veicoli nel garage");
            Console.WriteLine("4) Esci dal programma");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    InserisciVeicolo();
                    break;
                case "2":
                    EstraiVeicolo();
                    break;
                case "3":
                    StampaVeicoli();
                    break;
                case "4":
                    continua = false;
                    Console.WriteLine("Uscita dal programma.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }
    }

    static void InserisciVeicolo()
    {
        Console.WriteLine("\nSeleziona il tipo di veicolo da aggiungere:");
        Console.WriteLine("1) Moto");
        Console.WriteLine("2) Furgone");
        Console.WriteLine("3) Auto");
        Console.Write("Scelta: ");
        string tipo = Console.ReadLine();

        VeicoloAMotore veicolo = null;

        switch (tipo)
        {
            case "1":
                Console.Write("Marca: "); string marcaM = Console.ReadLine();
                Console.Write("Modello: "); string modelloM = Console.ReadLine();
                Console.Write("Anno: "); int annoM = int.Parse(Console.ReadLine());
                Console.Write("Alimentazione: "); string alimentazioneM = Console.ReadLine();
                Console.Write("Cilindrata: "); int cilindrataM = int.Parse(Console.ReadLine());
                veicolo = new Motocicletta(marcaM, modelloM, annoM, alimentazioneM, cilindrataM);
                break;

            case "2":
                Console.Write("Marca: "); string marcaF = Console.ReadLine();
                Console.Write("Modello: "); string modelloF = Console.ReadLine();
                Console.Write("Anno: "); int annoF = int.Parse(Console.ReadLine());
                Console.Write("Alimentazione: "); string alimentazioneF = Console.ReadLine();
                Console.Write("Capacità carico: "); int caricoF = int.Parse(Console.ReadLine());
                veicolo = new Furgone(caricoF, marcaF, modelloF, annoF, alimentazioneF, 0);
                break;

            case "3":
                Console.Write("Marca: "); string marcaA = Console.ReadLine();
                Console.Write("Modello: "); string modelloA = Console.ReadLine();
                Console.Write("Anno: "); int annoA = int.Parse(Console.ReadLine());
                Console.Write("Alimentazione: "); string alimentazioneA = Console.ReadLine();
                Console.Write("Cilindrata: "); int cilindrataA = int.Parse(Console.ReadLine());
                veicolo = new Automobile(4, marcaA, modelloA, annoA, alimentazioneA, cilindrataA);
                break;

            default:
                Console.WriteLine("Tipo veicolo non valido!");
                break;
        }

        if (veicolo != null)
        {
            int idx = garage.ImmettiNuovoVeicolo(veicolo);
            Console.WriteLine($"Veicolo inserito nel garage con indice {idx}.");
        }
    }

    static void EstraiVeicolo()
    {
        Console.Write("Inserisci l'indice del veicolo da estrarre: ");
        if (int.TryParse(Console.ReadLine(), out int idx))
        {
            VeicoloAMotore estratto = garage.EstraiVeicolo(idx);
            if (estratto != null)
            {
                Console.WriteLine("Veicolo estratto:");
                estratto.Stampa();
            }
            else
            {
                Console.WriteLine("Indice non valido o veicolo già assente.");
            }
        }
        else
        {
            Console.WriteLine("Indice non valido.");
        }
    }

    static void StampaVeicoli()
    {
        foreach (var v in garage.Veicoli)
        {
            if (v != null && v.InGarage)
                v.Stampa();
        }
    }
}
