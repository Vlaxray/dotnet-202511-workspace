public class Motocicletta : VeicoloAMotore
{
    public string Tipologia { get; set; }
    public int NumTempiMotore { get; set; }
    public Motocicletta(string marca, string modello, int annoImmatricolazione, string tipoAlimentazione, int cilindrata) : base(annoImmatricolazione, marca, modello, tipoAlimentazione, cilindrata)
    {
        this.Tipologia = "motocicletta";
        this.NumTempiMotore = 2;
    }
    public string GetTipologia()
    {
        return Tipologia;
    }
    public string SetTipologia(string tipologia)
    {
        return Tipologia = tipologia;
    }
    public int GetTempiMotore()
    {
        return NumTempiMotore;
    }
    public int SetTempiMotore(int tempiMotore)
    {
        return NumTempiMotore = tempiMotore;
    }
    public override string ToString()
    {
        return $"Marca: {this.Marca}, Modello: {this.Modello}, Anno immatricolazione: {this.AnnoImmatricolazione}, Tipologia: {this.Tipologia}, Numero tempi motore: {this.NumTempiMotore}";
    }
}