using System;

public class VeicoloAMotore
{
    public int AnnoImmatricolazione { get; set; }
    public string Marca { get; set; }
    public string Modello { get; set; }
    public string TipoAlimentazione { get; set; }
    public int Cilindrata { get; set; }

    public VeicoloAMotore(int anno, string marca, string modello, string tipoAlimentazione, int cilindrata)
    {
        this.AnnoImmatricolazione = anno;
        this.Marca = marca;
        this.Modello = modello;
        this.TipoAlimentazione = tipoAlimentazione;
        this.Cilindrata = cilindrata;
    }
    public bool InGarage { get; set; } = true;
    public int GetAnnoImmatricolazione()
    {
        return AnnoImmatricolazione;
    }
    public void SetAnnoImmatricolazione(int anno)
    {
        this.AnnoImmatricolazione = anno;
    }
    public string GetMarca()
    {
        return Marca;
    }
    public void SetMarca(string marca)
    {
        this.Marca = marca;
    }   public string GetTipoAlimentazione()
    {
        return TipoAlimentazione;
    }
    public void SetTipoAlimentazione(string tipoAlimentazione)
    {
        this.TipoAlimentazione = tipoAlimentazione;
    }
    public int GetCilindrata()
    {
        return Cilindrata;
    }
    public void SetCilindrata(int cilindrata)
    {
        this.Cilindrata = cilindrata;
    }
    public void Stampa() { Console.WriteLine($"AnnoImmatricolazione:{AnnoImmatricolazione},Marca:{Marca},Modello:{Modello},TipoAlimentazione:{TipoAlimentazione},Cilindrata:{Cilindrata}"); 
    }
}
