using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Numero di mazzi nello shoe
        Shoe shoe = new Shoe(6);
        shoe.GenerateShoe();
        shoe.Shuffle();

        // Creazione player e dealer
        Player player = new Player("Player1", 500); // banca iniziale
        Dealer dealer = new Dealer();

        Console.WriteLine("=== BLACKJACK GAME ===");

        while (true)
        {
            player.ClearCards();
            dealer.ClearCards();

            Console.WriteLine($"\nSaldo attuale: {player.Bank}");
            Console.Write("Inserisci puntata: ");

            double bet = Convert.ToDouble(Console.ReadLine());
            player.BetAmount(bet);

            Console.WriteLine("\n--- Distribuzione Carte ---");
            dealer.DealCard(player.Hand);
            dealer.DealCard(dealer.Hand);
            dealer.DealCard(player.Hand);
            dealer.DealCard(dealer.Hand);

            Console.WriteLine($"Dealer mostra: {dealer.Hand.Card[0]}");
            Console.WriteLine($"Le tue carte: {player.Hand} (Valore: {player.Hand.GetHandValue()})");

            // Controllo immediato BlackJack naturale
            if (player.Hand.GetHandValue() == 21)
            {
                Console.WriteLine("\nBLACKJACK! 💥");
                player.Winnings();
                continue;
            }

            // TURNO DEL PLAYER
            bool playerTurn = true;

            while (playerTurn)
            {
                Console.Write("\n(H)it - (S)tand - (D)oubleDown: ");
                string action = Console.ReadLine().ToUpper();

                switch (action)
                {
                    case "H":
                        player.Hit(shoe.PickCard());
                        shoe.RemoveCard();
                        Console.WriteLine($"Hai pescato: {player.Hand.Card[^1]}");
                        Console.WriteLine($"Nuovo valore: {player.Hand.GetHandValue()}");

                        if (player.CheckBusts())
                        {
                            Console.WriteLine("\nBUST! Hai sforato 21.");
                            playerTurn = false;
                        }
                        break;

                    case "S":
                        player.Stand(true);
                        playerTurn = false;
                        break;

                    case "D":
                        if (player.Bank >= player.Bet)
                        {
                            player.DoubleDown(shoe.PickCard());
                            shoe.RemoveCard();
                            Console.WriteLine($"Double Down! Hai pescato {player.Hand.Card[^1]}");
                        }
                        else
                        {
                            Console.WriteLine("Non hai abbastanza fondi per il Double Down.");
                        }
                        playerTurn = false;
                        break;

                    default:
                        Console.WriteLine("Comando non valido.");
                        break;
                }
            }

            // Se il player ha bustato → fine mano
            if (player.CheckBusts())
            {
                Console.WriteLine("\nHai perso la mano.");
                continue;
            }

            // TURNO DEL DEALER
            Console.WriteLine("\n--- Turno Dealer ---");
            Console.WriteLine($"Dealer mano: {dealer.Hand} (Valore: {dealer.Hand.GetHandValue()})");

            while (dealer.Hand.GetHandValue() < 17)
            {
                dealer.Hit();
                Console.WriteLine($"Dealer pesca: {dealer.Hand.Card[^1]} (totale: {dealer.Hand.GetHandValue()})");
            }

            if (dealer.CheckBusts())
            {
                Console.WriteLine("\nDealer BUST! Hai vinto!");
                player.Winnings();
                continue;
            }

            // RISULTATO FINALE
            int playerValue = player.Hand.GetHandValue();
            int dealerValue = dealer.Hand.GetHandValue();

            Console.WriteLine($"\n--- RISULTATO ---");
            Console.WriteLine($"Tuo valore: {playerValue}");
            Console.WriteLine($"Dealer valore: {dealerValue}");

            if (playerValue > dealerValue)
            {
                Console.WriteLine("🔥 Hai vinto!");
                player.Winnings();
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine("💀 Hai perso.");
            }
            else
            {
                Console.WriteLine("🤝 PUSH (pareggio)");
                player.Push();
            }

            Console.Write("\nVuoi giocare ancora? (Y/N): ");
            if (Console.ReadLine().ToUpper() != "Y")
                break;

            // Se lo shoe è quasi vuoto → reshuffle
            if (shoe.GetShoe().Count < 52)
            {
                Console.WriteLine("\nRimescolamento shoe...");
                shoe.GenerateShoe();
                shoe.Shuffle();
            }
        }

        Console.WriteLine("\nGrazie per aver giocato!");
    }
}
