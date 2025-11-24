public class Garage
{
    public VeicoloAMotore[] Veicoli { get; set; }
    public int NumeroVeicoli { get; set; }

    public Garage()
    {
        this.Veicoli = new VeicoloAMotore[10];
        this.NumeroVeicoli = 0;
    }
    public Garage(VeicoloAMotore[] Veicoli) : this() { }
    public int ImmettiNuovoVeicolo(VeicoloAMotore veicolo)
{
    for (int i = 0; i < Veicoli.Length; i++)
    {
        if (Veicoli[i] == null || !Veicoli[i].InGarage)
        {
            veicolo.InGarage = true; // segnala che il veicolo è ora nel garage
            Veicoli[i] = veicolo;
            return i;
        }
    }
    return -1; // garage pieno
}

    public VeicoloAMotore EstraiVeicolo(int idx)
{
    if (idx >= 0 && idx < Veicoli.Length && Veicoli[idx] != null && Veicoli[idx].InGarage)
    {
        Veicoli[idx].InGarage = false; // segna il veicolo come estratto
        return Veicoli[idx];
    }
    return null;
}



    //stampa per ogni posto la situazione dei posti
    public void StampaSituazionePosti()
    {
        for (int i = 0; i < NumeroVeicoli; i++)//per ogni posto occupato stampa le informazioni sul veicolo
        {
            Console.WriteLine($"Posto: {i}");
            Veicoli[i].Stampa();
        }
    }
    //dovrebbe stampare anche le caratteristiche dei Veicoli che stanno dentro
    public override string ToString()
    {
        for (int i = 0; i < NumeroVeicoli; i++)
        {
            Veicoli[i].ToString();
        }
        
        return $"{Veicoli}\n{NumeroVeicoli}";
        
        
        
    }
}


