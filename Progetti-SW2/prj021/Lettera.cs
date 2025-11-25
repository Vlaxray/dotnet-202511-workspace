public class Lettera
{
    public string Mittente { get; set; }
    public string Destinatario { get; set; }
    public int Priorita { get; set; }  // 0 = normale
    public bool RitornoMittente { get; set; } = false;

    public Lettera(string mittente, string destinatario)
    {
        Mittente = mittente;
        Destinatario = destinatario;
        Priorita = 0;
    }

    public override string ToString()
    {
        return $"mitt: {Mittente} destinatario:{Destinatario} priorità:{Priorita}";
    }
}
