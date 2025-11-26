using System;
using System.Collections.Generic;

public class Kata
{
    public static bool IsIsogram(string str)
    {
        str = str.ToLower();
        HashSet<char> seen = new HashSet<char>();

        foreach (char c in str)
        {
            if (seen.Contains(c))
                return false; // ripetizione trovata
            seen.Add(c);
        }

        return true; // nessuna ripetizione
    }
}
