using System;
using System.Linq;


// Esercizio 1 corretto 

int[] numeriSoloPari = new int[100]; // sostituiti da List
int indice=0;
int quantiElementiInArray = numeriSoloPari.Length;
for (int y = 1; y < 100; y++)
{
if (y % 2 == 0) // prende solo il pari
 {
numeriSoloPari[indice++] = y;
System.Console.WriteLine($"[{indice}] - {y} ");
 }
}
System.Console.WriteLine($"gli elementi sono={indice} l'indice massimo è {indice-1}");
System.Console.WriteLine();
System.Console.WriteLine();
for (int i = 0; i < indice; i++)
{
System.Console.Write($"{numeriSoloPari[i]} ");
}
System.Console.WriteLine();
quantiElementiInArray = indice;

// // ES 01 Variante con numeri casuali
// Random rnd = new Random();
// int sommaPari = 0;
// int countPari = 0;
// int numeroIterazione = 0;
// while (countPari < 100)
// {
// int n = rnd.Next(0, 21);
// Console.WriteLine($"Iterazione #{numeroIterazione} countPari={countPari} Generato pari:{n} sommaPari={sommaPari}");
// if (n % 2 == 0)
//  {
// sommaPari += n;
// countPari++;
//  }
// numeroIterazione++;
// }
// Console.WriteLine($"\nSomma dei primi 100 numeri pari casuali: {sommaPari}");


// // Esercizio 2 sommare i primi 100 numeri dispari 

// int [] numeriSoloDispari = new int[100];
// int quantiElementiInArray2 = numeriSoloDispari.Length;

// for (int y = 1; y < 100; y++)
// {
//     numeriSoloDispari[y] = (y * 2) - 1;
// }
// Console.WriteLine("Gli elementi dell'array sono: " + string.Join(", ", numeriSoloDispari) + ".");
// Console.WriteLine("L’array contiene " + quantiElementiInArray2 + " elementi.");
// Console.WriteLine("La somma degli elementi nell'array Dispari è " + numeriSoloDispari.Sum() + ".");
// Console.WriteLine(" ");
// Console.WriteLine(" ");
// Console.WriteLine(" ");


// // Esercizio 3 generare 100 numeri casuali e se pari moltiplicarli per 2 se dispari sottrarre 10, calcolare la somma risultante tra tutti
// // i numeri casuali devono essere compresi tra 0 e 20

int[] numeriCasuali = new int [100]; 
Random random = new Random();
for (int i = 0; i < numeriCasuali.Length; i++)
{
    numeriCasuali[i] = random.Next(0, 21);
}

int quantiElementiInArray3 = numeriCasuali.Length;
for (int i = 0; i < numeriCasuali.Length; i++)
{
   if (numeriCasuali[i] % 2 == 0)
   {
        numeriCasuali[i] = numeriCasuali[i] * 2;
   }
   else
   {
        numeriCasuali[i] = numeriCasuali[i] - 10;
   }
}
Console.WriteLine("L’array contiene " + quantiElementiInArray3 + " elementi.");
Console.WriteLine("Gli elementi dell'array sono: " + string.Join(", ", numeriCasuali) + ".");
Console.WriteLine("La somma degli elementi nell'array Numeri Casuali è " + numeriCasuali.Sum() + ".");


// // // Esercizio 4 sommare i primi 100 numeri pari

// //  int [] numeriSoloPari2 = new int[100];
// //  int quantiElementiInArray4 = numeriSoloPari2.Length;
// //   for (int y = 99; y >= 0; y--)
// //  {
// //      numeriSoloPari2[y] = y * 2;
// // }
// // Console.WriteLine("Gli elementi dell'array sono: " + string.Join(", ", numeriSoloPari2) + ".");
// // Console.WriteLine("L’array contiene " + quantiElementiInArray4 + " elementi.");
// // Console.WriteLine("La somma degli elementi nell'array Pari è " + numeriSoloPari2.Sum() + ".");
// // Console.WriteLine(" ");
// // Console.WriteLine(" ");
// // Console.WriteLine(" ");

// // // Esercizio 5 sommare i primi 100 numeri dispari 

// // int [] numeriSoloDispari = new int[100];
// // int quantiElementiInArray2 = numeriSoloDispari.Length;

// // for (int y = 99; y >= 0; y--)
// // {
// //     numeriSoloDispari[y] = (y * 2) - 1;
// // }
// // Console.WriteLine("Gli elementi dell'array sono: " + string.Join(", ", numeriSoloDispari) + ".");
// // Console.WriteLine("L’array contiene " + quantiElementiInArray2 + " elementi.");
// // Console.WriteLine("La somma degli elementi nell'array Dispari è " + numeriSoloDispari.Sum() + ".");
// // Console.WriteLine(" ");
// // Console.WriteLine(" ");
// // Console.WriteLine(" ");


// //Loop IN AVANTI

// int start= 0;
// int end = 100;
// int increment = 1;
// int somma = 0;
// for (int i = start; i < end; i += increment)
// {
// if (i % 2 == 0)
//     {
//         somma += i;
//     }
// }
// Console.WriteLine($"somma={somma}");

// increment = 2;
// somma = 0;
// for (int i = start; i < end; i += increment)
// {
//     {
//           somma += i;
//     }
// }
// Console.WriteLine($"somma={somma}");


// // loop all'indietro
// increment = 2;
// somma = 0;
// for (int i = end - increment; i >= start; i -= increment)
// {
//     {
//           somma += i;
//     }
// } 
// Console.WriteLine($"somma={somma}");
