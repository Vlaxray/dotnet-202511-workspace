public class Furgone : VeicoloAMotore
{
    public int CapacitaCarico { get; set; }
    public Furgone(int CapacitaCarico, string Marca, string modello, int annoImmatricolazione, string tipoAlimentazione, int cilindrata) : base(annoImmatricolazione, Marca, modello, tipoAlimentazione, cilindrata)
    {
        this.CapacitaCarico = CapacitaCarico;
    }
    public Furgone() : this(0,"","",0, "", 0) {}
    public int GetCapacitaCarico()
    {
        return CapacitaCarico;
    }
    public void SetCapacitaCarico(int CapacitaCarico)
    {
        this.CapacitaCarico = CapacitaCarico;
    }
    public override string ToString()
    {
        return "Numero porte: "+CapacitaCarico+"\n"+base.ToString();
    }
}