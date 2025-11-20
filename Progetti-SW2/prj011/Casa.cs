public class Casa
{
    public string Ubicazione { get; set; }
    public double Area { get; set; }
    public double PrezzoMetroQuadro { get; set; }
    public int NumeroStanze { get; set; }


    public Casa(string ubicazione, double area, double prezzoMetroQuadro, int numeroStanze)
    {
        Ubicazione = ubicazione;
        Area = area;
        PrezzoMetroQuadro = prezzoMetroQuadro;
        NumeroStanze = numeroStanze;
    }

    public void CalcolaValoreImmobiliare()
    {
        Console.WriteLine("Il valore immobiliare della casa è: " + (Area * PrezzoMetroQuadro)); // Stampa il risultato sul c
    }
    public override string ToString(){
      return $"{Ubicazione}, {Area}, {PrezzoMetroQuadro}, {NumeroStanze}";
    }
    public Casa()
    {   
        Ubicazione ="Via Roma";
        Area = 89.67;
        PrezzoMetroQuadro= 500.23;
        NumeroStanze = 4;
    }

}
