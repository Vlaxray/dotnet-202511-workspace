public class Vehicle
{
    public string PlateNumber { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }
    public List<Route> Routes { get; set; } 
    public Vehicle(string plateNumber, string model, int capacity)
    {
        this.PlateNumber = plateNumber;
        this.Model = model;
        this.Capacity = capacity;
        this.Routes = new List<Route>();
    }
    public Vehicle() : this("ABC-123", "Toyota Camry", 5) {}
    
    public void AddRoute(Route route)
    {
        if (!Routes.Contains(route))
            Routes.Add(route);
    }
    public void GetRoute(int index)
    {
        Console.WriteLine(Routes[index]);
    }
    public override string ToString()
    {
        return $"Plate Number: {this.PlateNumber}\nModel: {this.Model}\nCapacity: {this.Capacity}";
    }
    
    
}