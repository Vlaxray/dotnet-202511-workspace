using System;

public static class Kata
{
    public static int CountSheeps(bool[] sheeps)
    {
        int sommaPecore = 0;
        int sommaPecoreScappateDiCasa = 0;
        foreach (var s in sheeps)
        {
            if (s == true)
                sommaPecore += 1;
        }

        foreach (var s in sheeps)
        {
            if (s == false)
            {
                sommaPecoreScappateDiCasa += 1;
            }
        }
        Console.WriteLine("Il numero di pecore è: " + sommaPecore);
        Console.WriteLine("Il numero di pecore scappate da casa è: " + sommaPecoreScappateDiCasa);
        return sommaPecore;



    }
}
