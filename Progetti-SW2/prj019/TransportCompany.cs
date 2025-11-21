public class TransportCompany
{
    public string Name { get; set; }
    public string HeadQuarters { get; set; }

    public List<Vehicle> Vehicles { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Driver> Drivers { get; set; }

    public TransportCompany(string name, string headQuarters)
    {
        Vehicles = new List<Vehicle>();
        Employees = new List<Employee>();
        Drivers = new List<Driver>();
        Name = name;
        HeadQuarters = headQuarters;
    }

    public void AddEmployee(Employee employee)
    {
        if (employee is Driver driver)
            Drivers.Add(driver);
        else
            Employees.Add(employee);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public IEnumerable<Vehicle> GetFleet()
    {
        return Vehicles;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return Employees.Concat(Drivers);
    }
}
