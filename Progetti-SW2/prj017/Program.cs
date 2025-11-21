var Restaurant = new Restaurant();

Restaurant.AddMenu(new Menu());     
Restaurant.AddWaiter(new Waiter());

Restaurant restaurant = new Restaurant();
restaurant.AddMenu(new Menu());
restaurant.AddWaiter(new Waiter());
Waiter waiter = new Waiter();
Menu menu = new Menu();
Dish dish = new Dish();
Ingredient ingredient= new Ingredient();

Console.WriteLine(restaurant);
Console.WriteLine(waiter);
Console.WriteLine(menu);
Console.WriteLine(dish);
Console.WriteLine(ingredient);

