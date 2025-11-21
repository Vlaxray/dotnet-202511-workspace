public class Menu
{
    public string MenuName { get; set; }
    public string Category { get; set; }
    public List<Dish> Dishes { get; set; } = new List<Dish>();

    public Menu(string menuName, string category)
    {
        this.MenuName = menuName;
        this.Category = category;
    }
    public Menu() : this("Menu PizzaPazza", "A base di Pizza"){}
    public void AddDish(Dish dish) => Dishes.Add(dish);
    public override string ToString()
    {
        return $"Menu name: {this.MenuName}, Tipo: {this.Category}\n";
    }
}