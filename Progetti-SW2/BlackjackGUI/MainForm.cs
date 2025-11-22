using System;
using System.Drawing;
using System.Windows.Forms;
using BlackJack; // Namespace delle tue classi logiche

namespace BlackjackGUI
{
    public partial class MainForm : Form
    {
        // Carte del giocatore e del dealer
        private PictureBox[] playerCards;
        private PictureBox[] dealerCards;

        // Pulsanti di gioco
        private Button btnHit;
        private Button btnStand;
        private Button btnNewGame;

        // Label per punteggi e messaggi
        private Label lblPlayerScore;
        private Label lblDealerScore;
        private Label lblMessage;

        // Logica di gioco
        private Dealer dealer;
        private Player player;

        public MainForm()
        {
            
            // Impostazioni della finestra
            this.Text = "Blackjack GUI";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Inizializza logica del gioco
            dealer = new Dealer();
            player = new Player("Player1", 500);

            // Inizializza controlli
            InitializeCards();
            InitializeButtons();
            InitializeLabels();

            // Avvia nuova partita
            StartNewGame();
        }

        private void InitializeCards()
        {
            // Dealer: fila superiore
            dealerCards = new PictureBox[6];
            for (int i = 0; i < dealerCards.Length; i++)
            {
                dealerCards[i] = new PictureBox
                {
                    Location = new Point(50 + i * 120, 50),
                    Size = new Size(100, 150),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                this.Controls.Add(dealerCards[i]);
            }

            // Player: fila inferiore
            playerCards = new PictureBox[6];
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i] = new PictureBox
                {
                    Location = new Point(50 + i * 120, 350),
                    Size = new Size(100, 150),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                this.Controls.Add(playerCards[i]);
            }
        }

        private void InitializeButtons()
        {
            btnHit = new Button
            {
                Text = "Hit",
                Location = new Point(650, 350),
                Size = new Size(100, 50)
            };
            btnHit.Click += BtnHit_Click;
            this.Controls.Add(btnHit);

            btnStand = new Button
            {
                Text = "Stand",
                Location = new Point(650, 410),
                Size = new Size(100, 50)
            };
            btnStand.Click += BtnStand_Click;
            this.Controls.Add(btnStand);

            btnNewGame = new Button
            {
                Text = "New Game",
                Location = new Point(650, 470),
                Size = new Size(100, 50)
            };
            btnNewGame.Click += BtnNewGame_Click;
            this.Controls.Add(btnNewGame);
        }

        private void InitializeLabels()
        {
            lblPlayerScore = new Label
            {
                Text = "Player Score: 0",
                Location = new Point(50, 320),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblPlayerScore);

            lblDealerScore = new Label
            {
                Text = "Dealer Score: 0",
                Location = new Point(50, 20),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblDealerScore);

            lblMessage = new Label
            {
                Text = "",
                Location = new Point(350, 520),
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Red
            };
            this.Controls.Add(lblMessage);
        }

        private void StartNewGame()
        {
            dealer.ClearCards();
            player.ClearCards();

            dealer.Shoe.GenerateShoe();
            dealer.Shoe.Shuffle();

            // Pulisci PictureBox
            foreach (var pb in dealerCards) pb.Image = null;
            foreach (var pb in playerCards) pb.Image = null;

            lblMessage.Text = "";
            UpdateScores();

            DealInitialCards();
        }

        private void DealInitialCards()
        {
            player.AddCard(dealer.Shoe.PickCard());
            player.AddCard(dealer.Shoe.PickCard());

            dealer.AddCard(dealer.Shoe.PickCard());
            dealer.AddCard(dealer.Shoe.PickCard());

            UpdateCardImages();
            UpdateScores();
        }

        private void BtnHit_Click(object sender, EventArgs e)
        {
            player.AddCard(dealer.Shoe.PickCard());
            UpdateCardImages();
            UpdateScores();

            if (player.CheckBusts())
            {
                lblMessage.Text = "Player Bust!";
            }
        }

        private void BtnStand_Click(object sender, EventArgs e)
        {
            while (!dealer.CheckBusts() && dealer.HandValue() < 17)
            {
                dealer.AddCard(dealer.Shoe.PickCard());
            }

            UpdateCardImages();
            UpdateScores();

            int playerScore = player.HandValue();
            int dealerScore = dealer.HandValue();
            if (dealerScore > 21 || playerScore > dealerScore) lblMessage.Text = "Player Wins!";
            else if (dealerScore == playerScore) lblMessage.Text = "Push!";
            else lblMessage.Text = "Dealer Wins!";
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void UpdateCardImages()
        {
            for (int i = 0; i < playerCards.Length; i++)
            {
                if (i < player.Hand.Cards.Count)
                    playerCards[i].Image = Image.FromFile($"Assets/{player.Hand.Cards[i]}.png");
                else
                    playerCards[i].Image = null;
            }

            for (int i = 0; i < dealerCards.Length; i++)
            {
                if (i < dealer.Hand.Cards.Count)
                    dealerCards[i].Image = Image.FromFile($"Assets/{dealer.Hand.Cards[i]}.png");
                else
                    dealerCards[i].Image = null;
            }
        }

        private void UpdateScores()
        {
            lblPlayerScore.Text = $"Player Score: {player.HandValue()}";
            lblDealerScore.Text = $"Dealer Score: {dealer.HandValue()}";
        }
    }
}
