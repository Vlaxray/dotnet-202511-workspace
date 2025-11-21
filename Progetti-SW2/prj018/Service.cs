public class Service {
	public string Name { get; set; }
	public string Description { get; set; }
    public List<Activity> Activities { get; set; }

    public Service(string name, string description)
	{
        this.Name = name;
        this.Description = description;
        this.Activities = new List<Activity>();
    }

    
    public Service() : this("Servizio camera", "Colazione in camera"){}
    public override string ToString()
    {
        return $"Servizio: {this.Name}, Descrizione {this.Description}, Attività:{string.Join(",", this.Activities)}";
    }
    public void AddActivity(Activity activity)
    {
        if (activity != null)
            this.Activities.Add(activity);
    }
    public void getServices()
    {
        Console.WriteLine(this.ToString());
    }
}

