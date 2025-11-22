using BlackJack;
namespace BlackJack
{
    public class Dealer
    {
        public Shoe Shoe { get; private set; }
        public Hand Hand { get; private set; }
        public bool IsStanding { get; private set; }
        public bool IsVictor { get; private set; }

        public Dealer(int decks = 6)
        {
            Shoe = new Shoe(decks);
            Shoe.GenerateShoe();
            Shoe.Shuffle();

            Hand = new Hand();
            IsStanding = false;
            IsVictor = false;
        }

        public bool CheckBusts()
        {
            return Hand.CheckBusts();
        }

        public void DealHand()
        {
            Hand.Clear();
            Hand.AddCard(Shoe.PickCard());
            Hand.AddCard(Shoe.PickCard());
        }

        public Card DealCard(Hand hand)
        {
            var card = Shoe.PickCard();
            hand.AddCard(card);
            return card;
        }

        public void Hit()
        {
            Hand.AddCard(Shoe.PickCard());
        }

        public void DealerShuffle()
        {
            Shoe.Shuffle();
        }

        public void SetVictor(bool value)
        {
            IsVictor = value;
        }

        public void SetStanding(bool value)
        {
            IsStanding = value;
        }

        public void ClearCards()
        {
            Hand.Clear();
        }

        public override string ToString()
        {
            return $"Dealer Hand: {Hand} | Standing: {IsStanding} | Victor: {IsVictor}";
        }
    }
}