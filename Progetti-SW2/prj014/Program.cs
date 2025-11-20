// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

System.Console.WriteLine("#############");

var custumer1 = new Customer();

//Customer customer2 = new Customer();


custumer1.PlaceOrder(new Order());
custumer1.PlaceOrder(new Order());
custumer1.PlaceOrder(new Order());
custumer1.PlaceOrder(new Order("xx" , 99));
custumer1.PlaceOrder(new Order("xx" , 88 , new DateTime(2025 , 12 , 11)));


custumer1.ShowAllOrders();
System.Console.WriteLine("ORDINI RIMOSSI CON SUCCESSO \n\n\n");

custumer1.RemoveOrder();
custumer1.RemoveOrder();
custumer1.RemoveOrder();

custumer1.ShowAllOrders();
