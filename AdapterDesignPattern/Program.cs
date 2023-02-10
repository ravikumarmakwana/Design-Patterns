public class Program
{
    public static void Main(string[] args)
    {
        IEmployee employee = new EmployeeAdapter();
        Console.WriteLine(employee.GetAllEmployees());
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}

public interface IEmployee
{
    string GetAllEmployees();
}

public class EmployeeManager
{
    public List<Employee> Employees { get; set; }

    public EmployeeManager()
    {
        Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ram", Salary = 1234 },
            new Employee { Id = 2, Name = "Raj", Salary = 2345 },
            new Employee { Id = 3, Name = "Alice", Salary = 3456 }
        };
    }

    // Format Employees: [ "Ram", "Raj", "Alice"]
    public virtual string GetAllEmployees()
    {
        return $"Employees : [{string.Join(", ", Employees.Select(s => s.Name))}]";
    }
}

public class EmployeeAdapter : EmployeeManager, IEmployee
{
    // Format Employees: [ "Ram's Salary: 1234", "Raj's Salary: 2345", "Alice's Salary: 3456"]
    public override string GetAllEmployees()
    {
        return $"Employees: [{string.Join(", ", Employees.Select(s => $"{s.Name}'s Salary: {s.Salary}"))}]";
    }
}