
using System.Collections.Generic;


public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<Order> Orders { get; set; }

    public Customer() : this("mario" , "marios@gmail.com" , "333") { }


    //regola partire dal full
    public Customer(string name, string email, string phoneNumber)
    {
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Orders = new List<Order>();
    }


    /**
    Aggiunge un ordine alla lista degli ordini
    **/
    public void PlaceOrder(Order order)
    {
        if(order == null)
            return;

        this.Orders.Add(order);
    }

    public void RemoveOrder()
    {
        if(this.Orders.Count > 0)
            this.Orders.RemoveAt(0);
            //this.Orders.RemoveAt(this.Orders.Count - 1);
    }


    public void RemoveOrder(int posizioneDaRimuovere)
    {
        try
        {
            this.Orders.RemoveAt(posizioneDaRimuovere);
        }catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }


    public void RemoveAllElements()
    {
        this.Orders.Clear();
        //for(int i = 0; i < this.Orders.Count ; i++)
        //    this.Orders.RemoveAt(0);
        
    }

    public void ShowAllOrders()
    {
        foreach(Order order in this.Orders)
        System.Console.WriteLine(order);
    }


}