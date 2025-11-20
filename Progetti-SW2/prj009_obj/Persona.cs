using System;

public class Persona
{
    // Attributi
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }

    
    // costruttore di default
    public Persona()
    {
        Nome ="Mario";
        Cognome ="Rossi";
        Eta = 25;
    }

    // Costruttore
    public Persona(string nome, string cognome, int eta)
    {
        Nome = nome;
        Cognome = cognome;
        Eta = eta;
    }

    // Metodo per visualizzare le informazioni
    public void MostraInformazioni()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cognome: {Cognome}");
        Console.WriteLine($"Età: {Eta}");
    }
}
