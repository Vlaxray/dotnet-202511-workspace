using System;
using System.Linq;

public class Kata
{
    public static string PigIt(string str)
    {
        string[] words = str.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string w = words[i];

            // Se è punteggiatura, la lasciamo com'è
            if (w.Length == 1 && !char.IsLetter(w[0]))
                continue;

            // Pig Latin: sposta prima lettera in fondo + "ay"
            words[i] = w.Substring(1) + w[0] + "ay";
        }
        return string.Join(" ", words);
    }
}
