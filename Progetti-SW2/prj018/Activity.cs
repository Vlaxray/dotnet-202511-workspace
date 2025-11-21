public class Activity
{
    public string Title { get; set; }
    public int Duration { get; set; } //minutes
    public string Instructor { get; set; }
    public Activity(string title, int duration, string instructor)
    {   
        this.Title = title;
        this.Duration = duration;
        this.Instructor = instructor;
    }
    public Activity() : this("Corso di Tennis", 60, "Mario Rossi"){}
   
    public override string ToString()
    {
        return $"Attività: {Title}, Durata {Duration} minuti, Insegnante: {Instructor}";
    }   
}