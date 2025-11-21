public class Driver : Employee
{
    public string LicenseType { get; set; }


    public Driver(string fullname, int employeeID, string licenseType) :base(fullname,employeeID)
    {
        this.LicenseType = licenseType;
    }
    public Driver() : this("", 0,""){}
    public void Drive()
    {
        Console.WriteLine("I'm driving the truck on the road!");
    }  
}