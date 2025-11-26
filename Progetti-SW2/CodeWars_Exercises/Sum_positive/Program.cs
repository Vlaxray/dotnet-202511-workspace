using System;

public class Kata
{
    public static int PositiveSum(int[] arr)
    {
        int somma = 0;
        foreach (int i in arr)
            if (i > 0)
                somma += i;
        Console.WriteLine(somma);

        return somma;
    }
}
