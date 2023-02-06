public class Program
{
    public static void Main(string[] args)
    {
        var employees = GetEmployees();

        employees.ForEach(e =>
        {
            var salaryFactory = new SalaryFactory().Create(e);
            salaryFactory.CalculateSalary();
        });

        employees.ForEach(e =>
            Console.WriteLine($"{e.Id} | TotalSalary: {e.TotalSalary} | Bonus: {e.Bonus} | Commission: {e.Commision} | {e.EmployeeType}")
            );
    }
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                EmployeeType = EmployeeType.Junior,
                Factor1 = 10, Factor2 = 20, Factor3 = 30
            },
            new Employee
            {
                Id = 2,
                EmployeeType = EmployeeType.Senior,
                Factor1 = 10, Factor2 = 20, Factor3 = 30
            },
            new Employee
            {
                Id = 3,
                EmployeeType = EmployeeType.Lead,
                Factor1 = 10, Factor2 = 20, Factor3 = 30
            },
            new Employee
            {
                Id = 4,
                EmployeeType = EmployeeType.Manager,
                Factor1 = 10, Factor2 = 20, Factor3 = 30
            },
        };
    }
}

public enum EmployeeType
{
    Junior, Senior, Lead, Manager
}

public class Employee
{
    public int Id { get; set; }
    public int Factor1 { get; set; }
    public int Factor2 { get; set; }
    public int Factor3 { get; set; }

    public EmployeeType EmployeeType { get; set; }
    public int TotalSalary { get; set; }

    public int Commision { get; set; }
    public int Bonus { get; set; }
}

public interface ISalary
{
    int CalculateSalary(int factor1, int factor2, int factor3);
}
public class JuniorSalary : ISalary
{
    public int CalculateSalary(int factor1, int factor2, int factor3)
    {
        return factor1 + factor2 + factor3 + 100;
    }
}
public class SeniorSalary : ISalary
{
    public int CalculateSalary(int factor1, int factor2, int factor3)
    {
        return factor1 + factor2 + factor3 + 1000;
    }
}

public class LeadSalary : ISalary
{
    public int CalculateSalary(int factor1, int factor2, int factor3)
    {
        return factor1 + factor2 + factor3 + 10000;
    }

    public int CalculateBonus()
    {
        return 10000;
    }
}

public class ManagerSalary : ISalary
{
    public int CalculateSalary(int factor1, int factor2, int factor3)
    {
        return factor1 + factor2 + factor3 + 100000;
    }

    public int CalculateCommision()
    {
        return 100000;
    }
}

public abstract class BaseSalaryFactory
{
    protected Employee employee;

    protected BaseSalaryFactory(Employee employee)
    {
        this.employee = employee;
    }

    public abstract ISalary Create(Employee employee);

    public void CalculateSalary()
    {
        var instance = this.Create(employee);
        employee.TotalSalary = instance.CalculateSalary(employee.Factor1, employee.Factor2, employee.Factor3);
    }
}

public class JuniorSalaryFactory : BaseSalaryFactory
{
    public JuniorSalaryFactory(Employee employee)
        : base(employee) { }

    public override ISalary Create(Employee employee)
    {
        return new JuniorSalary();
    }
}

public class SeniorSalaryFactory : BaseSalaryFactory
{
    public SeniorSalaryFactory(Employee employee)
        : base(employee) { }

    public override ISalary Create(Employee employee)
    {
        return new SeniorSalary();
    }
}

public class LeadSalaryFactory : BaseSalaryFactory
{
    public LeadSalaryFactory(Employee employee)
        : base(employee) { }

    public override ISalary Create(Employee employee)
    {
        var instance = new LeadSalary();
        employee.Bonus = instance.CalculateBonus();
        return instance;
    }
}

public class ManagerSalaryFactory : BaseSalaryFactory
{
    public ManagerSalaryFactory(Employee employee)
        : base(employee) { }

    public override ISalary Create(Employee employee)
    {
        var instance = new ManagerSalary();
        employee.Commision = instance.CalculateCommision();
        return instance;
    }
}

public class SalaryFactory
{
    public BaseSalaryFactory Create(Employee employee)
    {
        BaseSalaryFactory instance;

        switch (employee.EmployeeType)
        {
            case EmployeeType.Junior:
                instance = new JuniorSalaryFactory(employee);
                break;
            case EmployeeType.Senior:
                instance = new SeniorSalaryFactory(employee);
                break;
            case EmployeeType.Lead:
                instance = new LeadSalaryFactory(employee);
                break;
            case EmployeeType.Manager:
                instance = new ManagerSalaryFactory(employee);
                break;
            default:
                instance = null;
                break;
        }

        return instance;
    }
}