public class Route
{
    public string RouteID { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public float DistanceKm { get; set; }

    public Route(string routeId, string origin, string destination, float distance)
    {
        this.RouteID = routeId;
        this.Origin = origin;
        this.Destination = destination;
        this.DistanceKm = distance;
    }
    public Route() : this( "066", "Texas", "California", 22f){}
    public override string ToString()
    {
        return $"Route ID: {this.RouteID}, Origin: {this.Origin}, Destination: {this.Destination}, Distance (km): {this.DistanceKm}";
    }
    public void GetSummary()
    {
        Console.WriteLine(this.ToString());
    }

}