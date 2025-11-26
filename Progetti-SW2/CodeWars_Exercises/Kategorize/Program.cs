using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

public class Kata
{
    public static IEnumerable<string> OpenOrSenior(int[][] data)
    {
        foreach (var item in data)
        {
            int age = item[0];
            int handicap = item[1];
            if (age > 54 && handicap > 7)
                yield return "Senior";
            else
                yield return "Open";
        }
    }
}