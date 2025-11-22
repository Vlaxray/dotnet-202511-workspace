using System.Text;
using BlackJack;
namespace BlackJack{
public class Hand
{
    public List<Card> Card { get; set; }
    public int Value { get; set; }
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
    public int GetHandAmount()
    {
        return this.Card.Count();
    }
    public int GetCards()
    {
        return this.Card.Count;
    }
    public int GetHandValue()
    {
        return this.Value;
    }
    public CharlieResult CheckCharlies()
    {
        if (this.GetHandValue() == 21 && this.GetCards() == 2)
            return CharlieResult.Blackjack;
        else
            return CharlieResult.Nothing;
    }
    public bool CheckBusts()
    {
        if (this.GetHandValue() > 21)
            return true;
        else
            return false;
    }
    public bool CheckBlackJack()
    {
        if (this.GetHandValue() == 21)
            return true;
        else
            return false;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in this.Card)
        {
            sb.Append(item.ToString());
            sb.Append(" ");
        }
        return sb.ToString();
    }
}
}