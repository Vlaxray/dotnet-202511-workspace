using System;

public class NthSeries
{

    public static string seriesSum(int n)
    {
        if (n == 0)
            return "0.00";
        double somma = 0.0;
        for (int m = 0; m < n; m++)
        {
            somma += 1.0 / (1 + 3 * m);
        }
        return somma.ToString("0.00");
    }
}
