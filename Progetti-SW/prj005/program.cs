using System;
using Somma; // <-- importa il namespace dove si trova SommaContenitore

class Program
{
    static void Main(string[] args)
    {
        // Chiami il metodo statico Somma e salvi il risultato
        int risultato = SommaContenitore.Somma("");

        Console.WriteLine($"Risultato finale dal metodo Somma: {risultato}");
    }
}
