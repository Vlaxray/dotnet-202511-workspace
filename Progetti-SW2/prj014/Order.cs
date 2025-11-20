/**

 

**/

public class Order
{
    
    public string OrderId { get; set; }
    public double TotalAmount { get; set; }

    public DateTime DateTime { get; set; }


    public Order() : this("YHH" , 100 , new DateTime(2025, 11, 20)){}



    public Order(string orderId, double totalAmount) 
        : this(orderId, totalAmount,  new DateTime(2025, 11, 20)){}



    /**
    public Order()
    {
        this.OrderId = "YHH";
        this.TotalAmount =100;
        this.DateTime = new DateTime(2025, 11, 20)
    }
    **/



    public Order(string orderId, double totalAmount, DateTime dateTime)
    {
        this.OrderId = orderId;
        this.TotalAmount = totalAmount;
        this.DateTime = dateTime;
    }

    public string GetOrderDetails()
    {
        return ToString();
    }

    public override string ToString()
    {
        return this.OrderId + " " + this.TotalAmount + " " + this.DateTime;
    }



}