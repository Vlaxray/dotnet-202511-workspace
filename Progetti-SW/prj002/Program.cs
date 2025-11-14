using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
int valore = Random.Shared.Next(-100, 100);

//Console.WriteLine(valore);
/*
int resto = valore %2; // se resto == 0 ==> pari , altrimenti dispari
Console.WriteLine($"Resto={resto}");

bool pariOppureDispari = resto ==0; //true ==pari false==dispari
System.Console.WriteLine($"Il numero {valore} è pari? {pariOppureDispari}");
*/
// se il numero è pari stampa il nmumero pari altrimenti stampa il numero dispari
/* if (pariOppureDispari)
{
    System.Console.WriteLine($"Il numero {valore} è PARI");
}
else
{
    System.Console.WriteLine($"Il numero {valore} è DISPARI");
}

// verificare se il numero è positivo, negativo o uguale a zero
//if(valore >0)
{
    Console.WriteLine($"Il numero {valore} è positivo");
}
//else if(valore <0)
//{
//    Console.WriteLine($"Il numero {valore} è negativo");
//}
//else
//{
//    Console.WriteLine($"Il numero è uguale a zero");
//}
*/


/*
for (int counter = (Random.Shared.Next(1, 100)); counter > 0; counter = counter - 1)
{
    valore = Random.Shared.Next(-100,100);
    Console.Write($"for[{counter}] Valore={valore}");
    if(valore % 2 ==0)
    {
        Console.WriteLine(" è PARI");
    }
    else
    {
        Console.WriteLine(" è DISPARI");
    }
}
*/


// for (int j = 0; j < 2; j++)
// {
//     Console.WriteLine("**********");
//     while (j < 1)
//     {
//         for (int i = 0; i < 6; i++)
//         {
//             Console.WriteLine("*        *");
//         }
//         break;
//     }


// }

// // incrementali

// int a = 100;
// Console.WriteLine($"Valore di a prima del blocco: {a++}");
// a = 100;
// Console.WriteLine($"Valore di a prima del blocco: {++a}");

// // stampare i numeri pari con ciclo for
// for (int k = 0; k < 1000; k++)
// {
//     if (k > 100)   
//     {
//     break;
//     }
//     if (k % 2 > 0 )
//     {
//         continue;
//     }
//     Console.WriteLine($"{k}");
// }
// Console.WriteLine();
// // stampare i numeri pari con ciclo while
// int y = 0;
// while (y < 1000)
// {
//     if (y > 30)
//     {
//         break;
//     }
//     if (y % 2 > 0)
//     {
//         y++;
//         continue;
//     }
//     Console.WriteLine($"{y}");
//     y++;

// }
// Console.WriteLine();





// esercizio 1 sommare i primi 100 numeri pari
// esercizio 2 sommare i dispari e sommare i dispari
// eservizio 3 generare 100 numeri casuali e se pari moltiplicarli per 2 se dispari sottrarre 10,  calcolare la somma risultante tra tutti
// i numeri casuali devono essere compresi tra 0 e 20





// Esercizio 1 sommare i primi 100 numeri pari
int [] numeriSoloPari = new int[100];
int y = Random.Shared.Next(0, 20);
int quantiElementiInArray = numeriSoloPari.Length;

for (y = 0; y < 99; y++)
{
        if (y % 2 > 0)
    {
        y++;
        continue;
    }
    numeriSoloPari[y] = y;
    y++;
}
Console.WriteLine("Gli elementi dell'array sono:" + string.Join(", ", numeriSoloPari) + ".");
Console.WriteLine("L’array contiene " + quantiElementiInArray + " elementi.");
Console.WriteLine("La somma degli elementi nell'array è" + numeriSoloPari.Sum() + ".");