using System;
public class Order {
	public string OrderID { get; set; }
    public DateTime Date { get; set; }
    public float TotalAmount { get; set; }

    //default constructor
    public Order()
    {   
        OrderID = "";
        Date = DateTime.Now;
        TotalAmount = 0.0f;
    }

    //costruttore parametrizzato
    public Order(string orderID, string date, float totalAmount) 
    {
        this.OrderID = orderID;
        this.Date = DateTime.Parse(date);
        this.TotalAmount = totalAmount;
    }
    public void GetOrderDetail()
    {
        Console.WriteLine("OrderID: " + OrderID);
        Console.WriteLine("Date: " + Date.ToString("dd/MM/yyyy"));
        Console.WriteLine("totalAmount: " + TotalAmount + "€");      
    }

    public void CancelOrder()
    {
        Console.WriteLine("Your order has been cancelled.");
    }
}