public class Shoe
{
    public int Decks { get; set; }
    public List<Card> Card { get; set; }
    public List<Card> ShoeCards { get; set; }

    public Shoe(int decks)
    {
        Decks = decks;
        Card = new List<Card>();
        ShoeCards = new List<Card>();

        for (int d = 0; d < decks; d++)
        {
            foreach (Card.SuitEnum suit in Enum.GetValues(typeof(Card.SuitEnum)))
            {
                foreach (Card.RankEnum rank in Enum.GetValues(typeof(Card.RankEnum)))
                {
                    Card.Add(new Card((int)suit, (int)rank));
                }
            }
        }
    }

    public void GenerateShoe()
    {
        ShoeCards = new List<Card>(Card);
        for (int i = 1; i < Decks; i++)
        {
            ShoeCards.AddRange(Card);
        }
    }

    public void Shuffle()
    {
        ShoeCards.Shuffle(); // se usi extension method corretto
    }

    public List<Card> GetShoe()
    {
        return ShoeCards;
    }

    public Card PickCard()
    {
        return ShoeCards[0];
    }

    public void RemoveCard()
    {
        ShoeCards.RemoveAt(0);
    }

    public override string ToString()
    {
        return $"Decks: {Decks}\nCards: {string.Join(", ", ShoeCards)}";
    }
}
