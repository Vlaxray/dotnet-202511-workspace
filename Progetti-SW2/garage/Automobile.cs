public class Automobile : VeicoloAMotore
{
    public int NumPorte { get; set; }
    public Automobile(int NumPorte, string Marca, string modello, int annoImmatricolazione, string tipoAlimentazione, int cilindrata) : base(annoImmatricolazione, Marca, modello, tipoAlimentazione, cilindrata)
    {
        this.NumPorte = NumPorte;
    }
    public Automobile() : this(0,"","",0, "", 0) {}
    public int GetNumPorte()
    {
        return NumPorte;
    }
    public void SetNumPorte(int NumPorte)
    {
        this.NumPorte = NumPorte;
    }
    public override string ToString()
    {
        return "Numero porte: "+NumPorte+"\n"+base.ToString();
    }
}