using System;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        // Crea un cliente
        Customer customer = new Customer("Giuseppe", "giuseppe32@gmail.com", "31991991991");

        // Carica un ordine random dal file
        Order randomOrder = LoadRandomOrder("C:/Users/valer/OneDrive/Desktop/listaOrdini.txt");

        // Stampa a console
        Console.WriteLine("Ordine casuale:");
        Console.WriteLine($"ID: {randomOrder.OrderID}");
        Console.WriteLine($"Data: {randomOrder.Date}");
        Console.WriteLine($"Totale: {randomOrder.TotalAmount}");
        
        //Cancella un ordine
        CancelOrder(randomOrder);
    }

    public static Order LoadRandomOrder(string path)
    {
        string[] lines = File.ReadAllLines(path);

        Random rnd = new Random();
        string randomLine = lines[rnd.Next(lines.Length)];

        string[] parts = randomLine.Split(';');

        string orderID = parts[0];
        string date = parts[1];
        float totalAmount = float.Parse(parts[2], CultureInfo.InvariantCulture);

        return new Order(orderID, date, totalAmount);
    }
    public static void CancelOrder(Order order)
    {
        order.CancelOrder(); 
    }
}
