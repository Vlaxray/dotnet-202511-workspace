public class Employee{
    public string FullName {get; set;}
    public int EmployeeID{ get;set;}

    public Employee(string fullName, int employeeId){
        this.FullName = fullName;
        this.EmployeeID=employeeId;
    }
    public Employee() : this("Gordon Freeman", 09) {}
    
    public void GetInfo(){
        Console.WriteLine($"Name: {FullName}, ID:{EmployeeID}");
    }
}
