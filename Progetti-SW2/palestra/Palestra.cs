using System;
using System.Collections.Generic;
using System.Linq;

public class Palestra
{
    private string _nome;
    private string _indirizzo;
    private string _telefono;
    private int _capienzaMassima;
    private List<Istruttore> _istruttori;
    private List<Abbonamento> _abbonamenti;

    public string Nome { get => _nome; set => _nome = value; }
    public string Indirizzo { get => _indirizzo; set => _indirizzo = value; }
    public string Telefono { get => _telefono; set => _telefono = value; }
    public int CapienzaMassima { get => _capienzaMassima; set => _capienzaMassima = value; }
    public List<Istruttore> Istruttori { get => _istruttori; set => _istruttori = value; }
    public List<Abbonamento> Abbonamenti { get => _abbonamenti; set => _abbonamenti = value; }

    public Palestra(string nome, string indirizzo, string telefono, int capienzaMassima, List<Istruttore> istruttori, List<Abbonamento> abbonamenti = null)
    {
        this._nome = nome;
        this._indirizzo = indirizzo;
        this._telefono = telefono;
        this._capienzaMassima = capienzaMassima;
        this._istruttori = istruttori ?? new List<Istruttore>();
        this._abbonamenti = Abbonamenti ?? new List<Abbonamento>();

    }
    public Palestra() : this("Palestra Dei Forti", "via dei Fortificanti", "+991234567890", 5, new List<Istruttore>(), new List<Abbonamento>()) { }

    public string GeneraReportMensile()
    {
        // Numero nuovi iscritti: conta gli abbonamenti attivi
        int nuoviIscritti = _abbonamenti.Count;

        // Frequenza media: media presenze dei corsi (tutte le partecipazioni)
        int totalePresenze = _istruttori.Sum(i => i.Corsi.Sum(c => c.Partecipazioni.Count(p => p.Presente)));
        int totalePartecipazioni = _istruttori.Sum(i => i.Corsi.Sum(c => c.Partecipazioni.Count));
        decimal frequenzaMedia = totalePartecipazioni > 0 ? (decimal)totalePresenze / totalePartecipazioni : 0m;

        // Incasso totale: somma importi di tutti gli abbonamenti
        decimal incassoTotale = _abbonamenti.Sum(a => a.Prezzo);

        return $"Nuovi iscritti: {nuoviIscritti}, Frequenza media: {frequenzaMedia:F2}, Incasso totale: {incassoTotale:C}";
    }


    public List<string> VerificaCapienzaCorsi()
    {
        var corsiOltreCapienza = new List<string>();
        foreach (var istruttore in _istruttori)
        {
            foreach (var corso in istruttore.Corsi)
            {
                if (corso.Partecipazioni.Count > _capienzaMassima)
                    corsiOltreCapienza.Add($"Corso {corso.Nome} supera capienza ({corso.Partecipazioni.Count}/{_capienzaMassima})");
            }
        }
        return corsiOltreCapienza;
    }


    public List<string> GestisciPromemoria()
    {
        var promemoria = new List<string>();
        foreach (var istruttore in _istruttori)
        {
            foreach (var corso in istruttore.Corsi)
            {
                foreach (var p in corso.Partecipazioni)
                {
                    if ((p.Data - DateTime.Now).TotalDays >= 25 && (p.Data - DateTime.Now).TotalDays <= 30)
                        promemoria.Add($"Inviare promemoria a {p.Membro.Name} per corso {corso.Nome}");
                }
            }
        }
        return promemoria;
    }

    public override string ToString()
    {
        return $"Nome: {_nome}, Indirizzo: {_indirizzo}, Numero Istruttori: {_istruttori.Count}";
    }
}
