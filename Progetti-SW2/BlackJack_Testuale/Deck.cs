namespace BlackJack
{
    public class Deck
    {
        private List<Card> Cards;
        private List<Card> DiscardPile;

        public Deck()
        {
            Cards = new List<Card>();
            DiscardPile = new List<Card>();
        }


        public enum Suit { Hearts, Diamonds, Clubs, Spades }
        public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public void CreateDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card((int)suit, (int)rank));
                }
            }
        }
        public void GetDeck()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public void PickCard()
        {
            Console.WriteLine(Cards[0].ToString());
            DiscardPile.Add(Cards[0]);
            Cards.RemoveAt(0);
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count(); i++)
            {
                int j = random.Next(1, 53);
                Card tempCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tempCard;
            }
            Cards.Shuffle();
        }
        public override string ToString()
        {
            return $"Cards: {string.Join(", ", Cards)}";
        }

    }

}