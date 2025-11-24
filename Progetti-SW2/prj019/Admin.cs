public class Admin : Employee
{
    public string Department { get; set; }
    public Admin(string fullname, int employeeID, string department) : base(fullname, employeeID)
    {
        Department = department;
    }
    public Admin() :this ("", 0,"")
    {}
    public void GenerateReport()
    {
        Console.WriteLine("Admin: Generating protocol n°1234567890");
    }

}