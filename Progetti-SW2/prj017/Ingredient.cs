using System;
public class Ingredient
{
    public string Name { get; set; }
    public string Quantity { get; set; }

    public Ingredient() : this("Carrots", "1") { }

    public Ingredient(string name, string quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public void GetDetail()
    {
        Console.WriteLine($"Name: {Name}, Quantity: {Quantity}");
    }
    public override string ToString()
    {
        return $"Name: {Name}, Quantity: {Quantity}";
    }
}
