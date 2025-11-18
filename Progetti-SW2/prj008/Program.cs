using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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

        // bool[] vett2 = { true, false, true, true, false, true, false, true , false, true, false, true, false, true, false, true, true};
        // int sommaTrue = 0;
        // int sommaFalse = 0;
        // foreach(bool valore in vett2)
        // {
        //     if(valore == true)
        //         {
        //             Console.WriteLine("Si - valore 'true'");
        //             sommaTrue ++;
        //         }
        //     else
        //         {
        //             Console.WriteLine("L'elemento in questa posizione i-esima è 'false'");
        //             sommaFalse ++;
        //         }
        // }
        // Console.WriteLine($"Numero di valori true: {sommaTrue}");
        // Console.WriteLine($"Numero di valori false: {sommaFalse}");
       
        // false -> occupato
        // true -> libero

        // bool[] postiAlCinema = { true, false, true, true, false, true, false, true, false, true, false, true, true};
        // foreach(bool posto in postiAlCinema)
        //     {
        //         Console.WriteLine(posto);
        //     }
        // //procedura che restituisca la prima posizione libera e la vada a occupare
        // foreach(bool posto in postiAlCinema)
        // {
        //     Console.WriteLine(posto);
        //     if(posto == true)
        //     {
        //         int indice = Array.IndexOf(postiAlCinema, posto);
        //         Console.WriteLine($"Il primo posto libero è in posizione: {indice}");
        //         postiAlCinema[indice] = false; // occupa il posto
        //         Console.WriteLine(postiAlCinema[indice]);
        //         break;
        //     }
        // }
        // foreach(bool posto in postiAlCinema)
        //     {
        //         Console.WriteLine(posto);
        //     }

        // dato un vettore

        // int[] elementoInteroNonCrescente = { 4, 8, 15, 11, 23, 42 };
        // int[] elementoInteroCrescente = { 3, 4, 5, 6, 7, 8, 9 };

        // bool crescente = true;

        // // Controllo array 1
        // for (int i = 0; i < elementoInteroNonCrescente.Length - 1; i++)
        // {
        //     if (elementoInteroNonCrescente[i] > elementoInteroNonCrescente[i + 1])
        //     {
        //         crescente = false;
        //         break; 
        //     }
        // }
        // Console.WriteLine(crescente ? "Array 1 è crescente" : "Array 1 non è crescente");

        // // Controllo array 2
        // crescente = true;
        // for (int i = 0; i < elementoInteroCrescente.Length - 1; i++)
        // {
        //     if (elementoInteroCrescente[i] > elementoInteroCrescente[i + 1])
        //     {
        //         crescente = false;
        //         break;
        //     }
        // }
        // Console.WriteLine(crescente ? "Array 2 è crescente" : "Array 2 non è crescente");

        // Esercizio delle 11:30
        // Si vuole creare una applicazione che chieda all'utente quanti elementi 
        // nel vettore vuole inserire, numero deve essere maggiore di zero altrimenti
        // richiedere

        // bool valido = true;
        // while(valido)
        // {
        //     Console.Write("Stabilisci la quantità di elementi da inserire nel vettore? ");
        //     int numeroElementi = Convert.ToInt32(Console.ReadLine());
        //     if(numeroElementi > 0)
        //     {
        //         int[] vettoreUtente = new int[numeroElementi];
        //         for(int i = 0; i < numeroElementi; i++)
        //         {
        //             Console.Write($"Inserisci l'elemento in posizione {i}: ");
        //             vettoreUtente[i] = Convert.ToInt32(Console.ReadLine());
        //         }
        //             Console.WriteLine("Gli elementi inseriti sono:");
        //         foreach(int elemento in vettoreUtente)
        //         {
        //             Console.WriteLine(elemento);
        //         }
        //         valido = false; 
        //     }
        //     else
        //     {
        //         Console.WriteLine("Errore: il numero deve essere maggiore e diverso da zero. Riprova.");
        //     }

    // int[] vettorino = { 2, 4, 6, 8, 10, 12, 14, 16, 19, 20 };
    // //sommare gli elementi che si trovano in posizione pari e sono pari

    // int somma = 0;
    
    // for(int i = 0; i < vettorino.Length; i+=2)
    //         {
    //             if(i %2 ==0 && vettorino[i] %  2 ==0)
    //             {
    //                 somma += vettorino[i];
    //             }
    //         }
    // Console.WriteLine($"La somma degli elementi in posizione pari e che sono pari è: {somma}");

    // //sommare gli elementi che si trovano in posizione dispari e sono dispari

    // int somma2 = 0;
    
    // for(int i = 0; i < vettorino.Length; i++)
    //         {
    //             if(i %2 != 0 && vettorino[i] %  2 !=0)
    //             {
    //                 somma2 += vettorino[i];
    //             }
    //         }
    // Console.WriteLine($"La somma degli elementi in posizione dispari e che sono dispari è: {somma2}");

    // Esercizio delle 12:22
    // Ritorna il numero di volte che un elemento compare
    
    int[] vett = { 1, 2, 3, 4, 5, 1, 3, 6, 2, 10 };
    Console.Write("Inserisci un numero da cercare nel vettore: ");
    int numeroCercato = Convert.ToInt32(Console.ReadLine());   
    int numeroPresenze = 0;
    string posizioni = "";
    foreach(int numero in vett)
        {
            if(numero == numeroCercato)
            {   
                numeroPresenze ++;
            }   
        }
    for(int i = 0; i < vett.Length; i++)
    {
        if(vett[i] == numeroCercato)
        {
            posizioni += i + " ";
        }
    }
    Console.WriteLine($"Il numero cercato si trova nelle posizioni: {posizioni}");
    Console.WriteLine($"il numero \"{numeroCercato}\" è presente {numeroPresenze} volte nel vettore.");

    }
}
