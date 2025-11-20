using System.Dynamic;

public class Customer {
	public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber {get;set;}
    public List<Order> Orders { get; set; }
    
    public Customer(string name, string email, string phoneNumber)
    {
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Orders = new List<Order>();
	}
    
    public void AddOrder(Order order)
    {
        this.Orders.Add(order);
    }
    public void LoadOrdersFromFile(string filePath)
    {
        List<Order> externalOrders = OrderLoader.LoadOrdersFromFile(filePath);

        foreach (Order order in externalOrders)
        {
            Orders.Add(order);
        }
    
    }
    public void ShowOrders()
    {
        foreach (var order in Orders)
        {
            Console.WriteLine(order);
        }
    }
}
  
 