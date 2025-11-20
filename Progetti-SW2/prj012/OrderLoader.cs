using System;
using System.Collections.Generic;
using System.IO;

public static class OrderLoader
{
    public static List<Order> LoadOrdersFromFile(string filePath)
    {
        List<Order> orders = new List<Order>();

        string[] lines = File.ReadAllLines("C:/Users/valer/OneDrive/Desktop/listaOrdini.txt");
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) 
                continue;
            string[] parts = line.Split(';');
            string id = parts[0];
            string date = parts[1];
            float amount = float.Parse(parts[2]);
            orders.Add(new Order(id, date, amount));
        }
        return orders;
    }
    
}
