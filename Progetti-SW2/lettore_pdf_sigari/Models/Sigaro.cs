using System;

namespace SigariListaPreziApp.Models
{
    public class Sigaro
    {
        public int Codice { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Confezione { get; set; } = string.Empty;
        public int Pezzi { get; set; }
        public decimal PrezzoKgConvenzionale { get; set; }
        public decimal PrezzoConfezione { get; set; }

        public override string ToString()
        {
            return $"{Codice} - {Nome}";
        }
    }
}