public class Booking
{
    public string BookingID { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Guest Guest { get; set; }

    
    public Booking(string bookingId, DateTime checkin, DateTime checkout)
    {
        this.BookingID = bookingId;
        this.CheckIn = checkin;
        this.CheckOut = checkout;
        this.Guest = new Guest();
    }
    
    public Booking() : this("222", DateTime.Now, DateTime.Now.AddDays(1)) {}
    public void AssignGuest(Guest guest) => Guest = guest;
    public void GetGuest()
    {
        
    }
    public override string ToString() => $"BookingID: {this.BookingID}, CheckIn {this.CheckIn.ToString()}, CheckOut {this.CheckOut.ToString()}, Guest: {this.Guest}"; 
    
}