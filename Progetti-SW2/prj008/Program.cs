using System;
using System.ComponentModel.Design;
using System.Linq;
public class HelloWorld
{
        public static void Main(string[] args)
    {
        // Console.Write("Calcola la tabellina del: ");
        // int numero = Convert.ToInt32(Console.ReadLine());
        // Console.Write("E moltipica fino al numero i-esimo : ");
        // int multi = Convert.ToInt32(Console.ReadLine());

        // for (int i = 1; i <= multi; i++)
        // {
        //     int risultato = numero * i;
        //     Console.WriteLine($"{numero} x {i} = {risultato}");
        // }

        // il programma chiede di inserire un certo numero di valori (positivi o negativi)

        // fino a che non si inserisce il valore 0; il programma fa la somma/differenza dei valori
        // Console.WriteLine("Inserisci numeri da sommare/sottrarre (inserisci 0 per terminare):");
        // int numeroUtente = Convert.ToInt32(Console.ReadLine());
        // int somma = 0;

        // while(numeroUtente != 0)
        // {
        //     somma += numeroUtente;
        //     Console.WriteLine($"Somma parziale: {somma}");
        //     numeroUtente = Convert.ToInt32(Console.ReadLine());
        //     Console.Write("Inserisci un numero (0 per terminare): ");
        // }



        // // // dato un vettorei inizializzato con 10 numeri interi, il programma restituisce il numero minimo,
        // // // il numero massimo e la media dei numeri presenti nell'array

        // int[] vett = { 5, 8, -3, 12, 7, -1, 0, 4, -22, 32, -6, 10 };

        // // restituisce il numero minimo dell'array
        // int minimo = vett[0]; // il primo elemento è il numero minimo
        // foreach(int numero in vett)
        // {
        //     if(numero < minimo)
        //     {
        //         minimo = numero;
        //     }
        //     else
        //     {
        //         continue;
        //     }
        
        // }
        // Console.WriteLine($"Il valore minimo è: {minimo}");
        
        // // restituisce il numero massimo dell'array
        // int massimo = vett[0];
        // foreach(int numero in vett)
        // {
        //     if(numero > massimo)
        //     {
        //         massimo = numero;
        //     }
        //     else
        //     {
        //         continue;
        //     }
        
        // }
        // Console.WriteLine($"Il valore massimo è: {massimo}");

        // // restituisce la media dei numeri presenti nell'array
        // int somma = 0;
        // foreach(int numero in vett)
        // {
        //     somma += numero;
        // }
        // double media = (double)somma / vett.Length;
        // Console.WriteLine($"La media è: {media}");

        bool[] vett2 = { true, false, true, true, false, false, true, false, true , false, true, false, true, false, true, false, true, true};
        int sommaTrue = 0;
        int sommaFalse = 0;
        foreach(bool valore in vett2)
        {
            if(valore == true)
                {
                    Console.WriteLine("Si - valore 'true'");
                    sommaTrue ++;
                }
            else
                {
                    Console.WriteLine("L'elemento in questa posizione i-esima è 'false'");
                    sommaFalse ++;
                }
        }
        Console.WriteLine($"Numero di valori true: {sommaTrue}");
        Console.WriteLine($"Numero di valori false: {sommaFalse}");
    
    

    }
}