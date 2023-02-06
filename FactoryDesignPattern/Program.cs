public class Program
{
    public static void Main(string[] args)
    {
        var employees = GetEmployees();

        employees.ForEach(e =>
        {
            var salaryInstance = SalaryFactory.GetSalaryInstance(e.EmployeeType);
            e.TotalSalary = salaryInstance.CalculateSalary(e.Factor1, e.Factor2, e.Factor3);
        });

        Console.WriteLine("Employee Salaries Details:");

        employees.ForEach(e =>
        {
            Console.WriteLine($"{e.Id} {e.TotalSalary} {e.EmployeeType}");
        });
    }
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                EmployeeType = EmployeeType.Junior,
                Factor1 = 10,
                Factor2 = 20,
                Factor3 = 30
            },
            new Employee
            {
                Id=2,
                EmployeeType = EmployeeType.Senior,
                Factor1= 10,
                Factor2= 20,
                Factor3= 30
            },
            new Employee
            {
                Id=3,
                EmployeeType = EmployeeType.Lead,
                Factor1= 10,
                Factor2= 20,
                Factor3= 30
            },
            new Employee
            {
                Id = 4,
                EmployeeType = EmployeeType.Manager,
                Factor1= 10,
                Factor2= 20,
                Factor3= 30
            }
        };
    }
}
