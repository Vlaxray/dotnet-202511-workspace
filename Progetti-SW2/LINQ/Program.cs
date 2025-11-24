int[] numeri = {1,2,3,6,2,4,5,7,8};
var numeriPari = from numero in numeri
                 where numero % 2 == 1
                 select numero;
foreach (var n in numeriPari)
{
    Console.WriteLine(n);
}