using System.Text;
using BlackJack;
using System.Collections.Generic;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> Card { get; set; }
        public int Value { get; set; }

        // Proprietà pubblica per GUI
        public List<Card> Cards => this.Card;

        public Hand()
        {
            this.Card = new List<Card>();
            this.Value = 0;
        }

        public void AddCard(Card card)
        {
            Card.Add(card);

            if (card.Rank == 1)
                Value += 11;
            else if (card.Rank >= 10)
                Value += 10;
            else
                Value += card.Rank;

            // gestione Asso se bust
            if (Value > 21)
            {
                foreach (var c in Card)
                {
                    if (c.Rank == 1 && Value > 21)
                        Value -= 10;
                }
            }
        }

        public enum CharlieResult
        {
            Nothing,
            Blackjack
        }

        public void Clear()
        {
            this.Card.Clear();
            this.Value = 0;
        }

        public int GetHandAmount() => this.Card.Count;
        public int GetCards() => this.Card.Count;
        public int GetHandValue() => this.Value;

        public CharlieResult CheckCharlies()
        {
            return this.GetHandValue() == 21 && this.GetCards() == 2 ? CharlieResult.Blackjack : CharlieResult.Nothing;
        }

        public bool CheckBusts() => this.GetHandValue() > 21;
        public bool CheckBlackJack() => this.GetHandValue() == 21;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.Card)
            {
                sb.Append(item.ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
