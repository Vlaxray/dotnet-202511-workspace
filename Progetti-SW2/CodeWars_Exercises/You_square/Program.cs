using System;

public class Kata
{
    public static bool IsSquare(int n)
    {
        double risultato = Math.Sqrt(n);
        if (n < 0)
        {
            Console.WriteLine("Negative numbers cannot be square");
            return false;
        }
        else if (risultato % 1 == 0)
        {
            Console.WriteLine("The number is square");
            return true;
        }
        else
        {
            Console.WriteLine("The number isn't square");
            return false;
        }
    }
}