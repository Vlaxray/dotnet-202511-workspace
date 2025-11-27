public class Kata
{
    public static string RemoveExclamationMarks(string s)
    {
        foreach (char c in s)
        {
            if (c == '!')
            {
                s = s.Replace("!", "");
            }
        }
        return s;

    }
}