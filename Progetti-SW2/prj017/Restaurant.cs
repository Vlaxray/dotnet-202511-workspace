public class Restaurant
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Menu> Menus { get; set; } 
    public List<Waiter> Waiters { get; set; }

    public Restaurant(string name, string address)
    {   
        this.Name = name;
        this.Address = address;
        this.Menus = new List<Menu>();
        this.Waiters = new List<Waiter>();
    }
    public Restaurant() : this("PizzeriaFranko", "via Francucci 10") {}
   
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