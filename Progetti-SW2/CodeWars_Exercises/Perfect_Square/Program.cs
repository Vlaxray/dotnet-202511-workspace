public class Kata
{
    public static long FindNextSquare(long num)
    {
        if (num < 0)
            return -1;

        long sqrt = (long)Math.Sqrt(num);

        
        if (sqrt * sqrt == num)
        {
            long next = sqrt + 1;
            return next * next;
        }
        else
        {
            return -1;
        }
    }
}
