public class Room
{
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public float PricePerNight { get; set; }
    public List<Booking> Bookings { get; set; }

    public Room(int roomNumber, string type, float pricePerNight)
    {
        this.RoomNumber = roomNumber;
        this.Type = type;
        this.PricePerNight = pricePerNight;
        this.Bookings = new List<Booking>();
    }
    public Room() : this(303, "Standard", 900.50f) { }
    public void AddBooking(Booking booking) => Bookings.Add(booking);
    public override string ToString()
    {
        return $"{this.RoomNumber}, {this.Type}, {this.PricePerNight}";
    }
    public void GetBookings() => Console.WriteLine(Bookings);
}