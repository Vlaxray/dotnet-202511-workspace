public class Restaurant
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Menu> Menus { get; set; } = new();
    public List<Waiter> Waiters { get; set; } = new();

    public Restaurant(string name, string address, List<Menu> menus, List<Waiter> waiters)
    {   
        this.Name = name;
        this.Address = address;
        this.Menus = menus;
        this.Waiters = waiters;
    }
    public Restaurant() : this("PizzeriaFranko", "via Francucci 10", new List<Menu>(), new List<Waiter>()) {}
   
    public void AddMenu(Menu menu)
    {
        this.Menus.Add(menu);
    }
    public void AddWaiter(Waiter waiter)
    {
        this.Waiters.Add(waiter);
    }
    public override string ToString()
    {
        return $"Name: {this.Name}\nAddress: {this.Address}";
    }   
}