using System;
public class Guest
{
    public string Fullname { get; set; }
    public string DocumentID { get; set; }
    public string Phone { get; set; }

    public Guest() : this("PattySmith", "ID909", "1234567890") { }

    public Guest(string Fullname, string documentID, string phone)
    {
        this.Fullname = Fullname;
        this.DocumentID = documentID;
        this.Phone = phone;
    }
    public void GetSummary()
    {
        Console.WriteLine($"Fullname: {Fullname}, Document ID: {DocumentID}, Phone Number: {Phone}");
    }
    
    public override string ToString()
    {
        return $"Fullname: {Fullname} - ID: {DocumentID} - Phone: {Phone}";
    }
}
