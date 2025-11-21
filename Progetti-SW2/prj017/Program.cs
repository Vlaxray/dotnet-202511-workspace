var Restaurant = new Restaurant();

Restaurant.AddMenu(new Menu());     
Restaurant.AddWaiter(new Waiter());

Restaurant r = new Restaurant();
r.AddMenu(new Menu());
r.AddWaiter(new Waiter());
Waiter w = new Waiter();
Menu m = new Menu();
Dish d = new Dish();
Ingredient i= new Ingredient();

Console.WriteLine(r);
Console.WriteLine(w);
Console.WriteLine(m);
Console.WriteLine(d);
Console.WriteLine(i);

