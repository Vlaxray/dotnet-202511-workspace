using BlackJack;
namespace BlackJack
{
public class Player
{
    public Hand Hand { get; private set; }
    public string Name { get; private set; }
    public double Bank { get; private set; }
    public double Bet { get; private set; }
    public bool IsStanding { get; private set; }
    public bool IsVictor { get; private set; }

    public Player(string name, double bank)
    {
        Name = name;
        Bank = bank;
        Bet = 0;
        Hand = new Hand();
        IsStanding = false;
        IsVictor = false;
    }


    public bool CheckBusts()
    {
        return Hand.CheckBusts();
    }
    public void Hit(Card card)
    {
        Hand.AddCard(card);
    }

    public void Stand(bool stand)
    {
        IsStanding = stand;
    }

    public void DoubleDown(Card card)
    {
        // Puntata raddoppiata
        Bank -= Bet;
        Bet *= 2;

        Hand.AddCard(card);
        IsStanding = true;
    }

    public void BetAmount(double amount)
    {
        if (amount > Bank)
            throw new Exception("Saldo insufficiente.");

        Bet = amount;
        Bank -= amount;
    }

    public void Winnings()
    {
        Bank += Bet * 2;
        Bet = 0;
    }

    public void Push()
    {
        Bank += Bet;
        Bet = 0;
    }

    public void Insurance(Hand dealerHand, double sidebet)
    {
        if (dealerHand.GetHandValue() == 21)
            Bank += sidebet * 2; // incasso assicurazione

        // in ogni caso l’assicurazione è pagata subito
        Bank -= sidebet;
    }

    public void SetVictor(bool vic)
    {
        IsVictor = vic;
    }

    public bool GetIsVictor()
    {
        return IsVictor;
    }

    public bool GetIsStanding()
    {
        return IsStanding;
    }

    public void ClearCards()
    {
        Hand.Clear();
        Bet = 0;
        IsStanding = false;
        IsVictor = false;
    }

    public string GetName()
    {
        return Name;
    }

    public double GetBank()
    {
        return Bank;
    }

    public Hand GetHand()
    {
        return Hand;
    }

    public override string ToString()
    {
        return $"{Name} | Bank: {Bank} | Hand: {Hand}";
    }
}
}