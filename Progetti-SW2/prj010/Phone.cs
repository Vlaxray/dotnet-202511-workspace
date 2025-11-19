using System;
using System.Diagnostics.Contracts;

public class Phone
{
    // Attributi
    public string Marca { get; set; }
    public string Modello { get; set; }
    public int Prezzo { get; set; } 
    public bool IsDualSim { get; set; }

      // Costruttore parametrizzato
    public Phone(string marca, string modello, int prezzo, bool isDualSim)
    {
        Marca = marca;
        Modello = modello;
        Prezzo = prezzo;
        IsDualSim = isDualSim;
    }
    // costruttore di default
    public Phone()
    {
        Marca = "Nokia";
        Modello = "GSMTour";
        Prezzo = 500;
        IsDualSim = true;
    }

  

    // Metodo per visualizzare le informazioni
    public void MostraInformazioni()
    {
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modello: {Modello}");
        Console.WriteLine($"Prezzo: {Prezzo}");
        Console.WriteLine($"isDualSim: {IsDualSim}");
    } 
} 
    // Override del metodo ToString
