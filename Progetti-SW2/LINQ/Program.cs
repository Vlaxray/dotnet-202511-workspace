int[] numeri = { 1, 1, 1, 22, 1, 3, 3, 4 };
// var numeriPari = from numero in numeri
//                  where numero % 2 == 0
//                  select numero;
// foreach (var n in numeriPari)
// {
//     Console.WriteLine(n);
// }
int[] numeriUnici = numeri.Distinct().ToArray();
Console.WriteLine(string.Join(",", numeriUnici));
