var transportCompany = new TransportCompany("My Company", "Milan");

// Creazione oggetti
Vehicle vehicle = new Vehicle();
Employee employee = new Employee();
Driver driver = new Driver();
Admin admin = new Admin();
Route route = new Route();

// Aggiunta a TransportCompany
transportCompany.AddVehicle(vehicle);
transportCompany.AddEmployee(employee);
transportCompany.AddEmployee(driver);
transportCompany.AddEmployee(admin);
admin.GenerateReport();
driver.Drive();
employee.GetInfo();

// Output degli oggetti
Console.WriteLine(vehicle);
Console.WriteLine(route);



