public class Card
{
    public int Suit { get; set; }
    public int Rank { get; set; }
    public int Value { get; set; }

    public Card(int suit, int rank)
    {
        Suit = suit;
        Rank = rank;
    }
    public Card() : this(1, 1) { }
    public enum SuitEnum { Hearts, Diamonds, Clubs, Spades }
    public enum RankEnum { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public void ChangeAce()
    {
        if (Rank == 1) Rank = 14;
    }
    public void GetSuit()
    {
        if (Suit == 1) Console.WriteLine("Spades");
        else if (Suit == 2) Console.WriteLine("Hearts");
        else if (Suit == 3) Console.WriteLine("Diamonds");
        else if (Suit == 4) Console.WriteLine("Clubs");
    }
    public void GetRank()
    {
        switch (Rank)
        {
            case 1: Console.WriteLine("Ace"); break;
            case 2: Console.WriteLine("Two"); break;
            case 3: Console.WriteLine("Three"); break;
            case 4: Console.WriteLine("Four"); break;
            case 5: Console.WriteLine("Five"); break;
            case 6: Console.WriteLine("Six"); break;
            case 7: Console.WriteLine("Seven"); break;
            case 8: Console.WriteLine("Eight"); break;
            case 9: Console.WriteLine("Nine"); break;
            case 10: Console.WriteLine("Ten"); break;
            case 11: Console.WriteLine("Jack"); break;
            case 12: Console.WriteLine("Queen"); break;
            default: Console.WriteLine("King"); break;
        }
    }
    public int GetValue()
    {

        if (Rank == 1) return 11;       // Asso (temporaneo)
        if (Rank >= 10) return 10;      // 10 - J - Q - K
        return Rank;                    // 2–9
    }
    public override string ToString()
    {
        return $"{Suit}{Rank}";
    }
}