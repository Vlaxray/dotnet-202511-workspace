public class CentraleSmistaPosta
{
    public string CodiceCentrale { get; set; }
    public List<Lettera> Lettere { get; private set; }

    public CentraleSmistaPosta(string codice)
    {
        CodiceCentrale = codice;
        Lettere = new List<Lettera>();
    }

    public void RiceviLettera(Lettera lettera)
    {
        Lettere.Add(lettera);
    }

    public void SmistaLettera()
    {
        foreach (var item in Lettere)
        {
            if (item.Priorita == 0)
            {
                Console.WriteLine("La lettera con destinatario " + item.Destinatario + " è stata ritornata al mittente");
            }
            else
            {
                item.RitornoMittente = true;
            }
            
        }
    }
}
