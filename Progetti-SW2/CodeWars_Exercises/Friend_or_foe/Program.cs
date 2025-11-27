using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Kata
{
    public static IEnumerable<string> FriendOrFoe(string[] names)
    {
        List<string> result = new List<string>();

        foreach (string name in names)
        {
            if (name.Length == 4)
            {
                result.Add(name);
            }
        }

        return result;
    }
}
