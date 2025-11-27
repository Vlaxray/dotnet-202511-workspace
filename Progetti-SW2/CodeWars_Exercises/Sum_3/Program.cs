using System;

public class Sum
{
    public int GetSum(int a, int b)
    {
        int somma1 = 0;
        int somma2 = 0;

        if (a < b)
        {
            for (int i = a; i <= b; i++)
            {
                somma1 += i;
            }
            return somma1;
        }
        else if (a == b)
        {
            return a;
        }
        else
        {
            for (int i = b; i <= a; i++)
            {
                somma2 += i;
            }
            return somma2;
        }
    }
}
