using System;
using System.IO;
using System.Globalization;

public class Randomizer
{
    public static Order LoadRandomOrder(string path)
    {
        string[] lines = File.ReadAllLines("C:/Users/valer/OneDrive/Desktop/listaOrdini.txt");

        Random rnd = new Random();
        string randomLine = lines[rnd.Next(lines.Length)];

        string[] parts = randomLine.Split(';');
        string orderID = parts[0];
        string date = parts[1];
        float totalAmount = float.Parse(parts[2], CultureInfo.InvariantCulture); // <- punto come separatore
        return new Order(orderID, date, totalAmount);
    }
}
