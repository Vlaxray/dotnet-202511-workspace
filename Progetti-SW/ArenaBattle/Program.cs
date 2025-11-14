using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArenaBattle
{
    public partial class Form1 : Form
    {
        private List<Guerriero> guerrieri = new List<Guerriero>();
        private Guerriero giocatore;
        private Guerriero nemico;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            InizializzaGuerrieri();
            MostraGuerrieri();
        }

        private void InizializzaGuerrieri()
        {
            guerrieri.Add(new Guerriero("Thor", 100, 20, 10));
            guerrieri.Add(new Guerriero("Ares", 110, 18, 12));
            guerrieri.Add(new Guerriero("Athena", 90, 22, 8));
            guerrieri.Add(new Guerriero("Loki", 80, 25, 5));
            guerrieri.Add(new Guerriero("Zeus", 120, 15, 15));
        }

        private void MostraGuerrieri()
        {
            listBoxGuerrieri.DataSource = guerrieri;
            listBoxGuerrieri.DisplayMember = "Nome";
        }

        private void btnScegli_Click(object sender, EventArgs e)
        {
            giocatore = (Guerriero)listBoxGuerrieri.SelectedItem;
            do
            {
                nemico = guerrieri[rnd.Next(guerrieri.Count)];
            } while (nemico == giocatore);

            textBoxLog.Text = $"Hai scelto {giocatore.Nome}!\r\nNemico: {nemico.Nome}\r\n\r\n";
        }

        private void btnCombatti_Click(object sender, EventArgs e)
        {
            if (giocatore == null || nemico == null) return;

            while (giocatore.Vita > 0 && nemico.Vita > 0)
            {
                giocatore.Attacca(nemico);
                if (nemico.Vita <= 0) break;
                nemico.Attacca(giocatore);
            }

            string vincitore = giocatore.Vita > 0 ? giocatore.Nome : nemico.Nome;
            textBoxLog.AppendText($"Vince {vincitore}!\r\n");
        }
    }

    public class Guerriero
    {
        public string Nome { get; }
        public int Vita { get; set; }
        public int Attacco { get; }
        public int Difesa { get; }

        private Random rnd = new Random();

        public Guerriero(string nome, int vita, int attacco, int difesa)
        {
            Nome = nome;
            Vita = vita;
            Attacco = attacco;
            Difesa = difesa;
        }

        public void Attacca(Guerriero bersaglio)
        {
            int danno = Math.Max(0, Attacco - bersaglio.Difesa / 2 + rnd.Next(-3, 3));
            bersaglio.Vita -= danno;
            if (bersaglio.Vita < 0) bersaglio.Vita = 0;
        }

        public override string ToString() => $"{Nome} (Vita: {Vita})";
    }
}
