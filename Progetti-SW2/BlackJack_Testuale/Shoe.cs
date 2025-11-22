using BlackJack;
namespace BlackJack
{
public class Shoe
{
    public int Decks { get; }
    public List<Card> ShoeCards { get; private set; }

    public Shoe(int decks)
    {
        Decks = decks;
        ShoeCards = new List<Card>();
    }

    public void GenerateShoe()
    {
        ShoeCards.Clear();

        for (int d = 0; d < Decks; d++)
        {
            foreach (Card.SuitEnum suit in Enum.GetValues(typeof(Card.SuitEnum)))
            {
                foreach (Card.RankEnum rank in Enum.GetValues(typeof(Card.RankEnum)))
                {
                    ShoeCards.Add(new Card((int)suit, (int)rank));
                }
            }
        }
    }

    public void Shuffle()
    {
        ShoeCards.Shuffle();
    }

    public Card PickCard()
    {
        var c = ShoeCards[0];
        ShoeCards.RemoveAt(0);
        return c;
    }

    public override string ToString()
    {
        return $"Decks: {Decks}, Total Cards: {ShoeCards.Count}";
    }
}
}