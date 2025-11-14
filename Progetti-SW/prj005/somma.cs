using System;

namespace Somma;

public static class SommaContenitore
{
    public static int Somma(string args)
    {
        // ES 01 Variante con numeri casuali
        Random rnd = new Random();
        int sommaPari = 0;
        int countPari = 0;
        int numeroIterazione = 0;
        while (countPari < 100)
        {
            int n = rnd.Next(0, 21);
            Console.WriteLine($"Iterazione #{numeroIterazione} countPari={countPari} Generato pari:{n} sommaPari={sommaPari}");
            if (n % 2 == 0)
            {
                sommaPari += n;
                countPari++;
            }
            numeroIterazione++;
        }
        Console.WriteLine($"\nSomma dei primi 100 numeri pari casuali: {sommaPari}");

        return sommaPari;
    }
}
