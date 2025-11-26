public static class Kata
{
    public static int SquareSum(int[] numbers)
    {
        int somma = 0;
        foreach (int n in numbers)
        {
            somma += n * n;
        }
        return somma;
    }
}