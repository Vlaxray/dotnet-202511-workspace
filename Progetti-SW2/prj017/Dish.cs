public class Dish
{
    public string Name { get; set; }
    public float Price { get; set; }

    public List<Ingredient> Ingredients { get; set; }

    public Dish(string name, float price)
    {
        this.Name = name;
        this.Price = price;
        this.Ingredients = new List<Ingredient>();
    }
    public Dish() : this("Pizza", 5f) {}
    public void AddIngredients(Ingredient ingredient) => this.Ingredients.Add(ingredient);
    public void GetIngredients()
    {
        foreach (var item in this.Ingredients)
            Console.WriteLine(item.ToString());
    }
    public override string ToString() => $"Piatto: {this.Name}, Prezzo: {this.Price}$";
    
}