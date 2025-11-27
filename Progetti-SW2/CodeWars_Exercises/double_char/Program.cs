using System.Text;
public class Kata
{
    public static string DoubleChar(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            sb.Append(c);
            sb.Append(c); // aggiunge due volte lo stesso carattere
        }
        return sb.ToString();
    }
}
