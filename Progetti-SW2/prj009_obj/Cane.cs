using System;

public class Cane
{
    // Attributi
    public string Nome { get; set; }
    public string Taglia { get; set; }
    public int Eta { get; set; }

    
  

    // Costruttore
    public Cane(string nome, string taglia, int eta)
    {
        Nome = nome;
        Taglia = taglia;
        Eta = eta;
    }

    // Metodo per visualizzare le informazioni
    public void MostraInformazioni()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Taglia: {Taglia}");
        Console.WriteLine($"Età: {Eta}");
    }
}