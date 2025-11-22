using System;

public class Dealer
{
    public Shoe Shoe;
    public Hand Hand;
    public bool IsStanding;
    public bool IsVictor;

    public Dealer()
    {
        Shoe = new Shoe(6);   // oppure passa il numero di mazzi da fuori
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
        Shoe.RemoveCard();

        Hand.AddCard(Shoe.PickCard());
        Shoe.RemoveCard();
    }

    public Card DealCard(Hand Hand)
    {
        var card = Shoe.PickCard();
        Hand.AddCard(card);
        Shoe.RemoveCard();
        return card;               // rimuovi dal mazzo
    }

    public Hand GetHand()
    {
        return Hand;
    }

    public void Hit()
    {
        Hand.AddCard(Shoe.PickCard());
        Shoe.RemoveCard();
    }

    public void DealerShuffle()
    {
        Shoe.Shuffle();
    }

    public bool GetIsVictor()
    {
        return IsVictor;
    }

    public void SetVictor(bool vic)
    {
        IsVictor = vic;
    }

    public bool GetIsStanding()
    {
        return IsStanding;
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
        return $"Dealer Hand: {Hand.ToString()} | Standing: {IsStanding} | Victor: {IsVictor}";
    }
}
