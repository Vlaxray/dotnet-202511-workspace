public class LetteraPrioritaria : Lettera
{
    public LetteraPrioritaria(string mittente, string destinatario, int priorita)
        : base(mittente, destinatario)
    {
        Priorita = priorita; // usa la proprietà della classe base
    }
}
