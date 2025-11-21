public class Waiter {
	public string Id { get; set; }
	public string FullName { get; set; }
    public string Shift { get; set; }

    public Waiter(string id, string fullName, string shift)
	{
        this.Id = id;
        this.FullName = fullName;
        this.Shift = shift;
    }
    public Waiter() : this("123", "Franko Frankovich", "mattina"){}
    public override string ToString()
    {
        return $"ID: {this.Id}, FullName {this.FullName}, Shift: {this.Shift}";
    }
}