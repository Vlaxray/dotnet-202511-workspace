public class Hotel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Stars { get; set; }
    public List<Room> Room { get; set; }
    public List<Service> Services { get; set; }

    public Hotel(string name, string address, int stars)
    {
        this.Name = name;
        this.Address = address;
        this.Stars = stars;
        this.Room = new List<Room>();
        this.Services = new List<Service>();
    }
    public Hotel() : this("Default", "Default", 4) { }
    public void AddRoom(Room room)
    {
        this.Room.Add(room);
    }
    public void AddService(Service service)
    {
        this.Services.Add(service);
    }
    public override string ToString()
    {
        return $"Name: {this.Name}\nAddress: {this.Address}\nStars: {this.Stars}";
    }


}
