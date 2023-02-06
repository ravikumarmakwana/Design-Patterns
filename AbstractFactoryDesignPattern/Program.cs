public class Program
{
    public static void Main(string[] args)
    {
        var employees = GetEmployees();

        employees.ForEach(e =>
        {
            var computerFactory = new EmployeeSystemFactory().Create(e);
            e.ComputerType = $"{computerFactory.Brand().GetBrand()} {computerFactory.SystemType().GetSystemType()}";
        });

        employees.ForEach(e =>
        {
            Console.WriteLine($"{e.Id} | {e.EmployeeType} | {e.PositionType} | {e.ComputerType}");
        });
    }

    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                EmployeeType = EmployeeType.Permanent,
                PositionType = PositionType.Manager
            },
            new Employee
            {
                Id = 2,
                EmployeeType = EmployeeType.Permanent,
                PositionType = PositionType.NonManager
            },
            new Employee
            {
                Id = 3,
                EmployeeType = EmployeeType.Contract,
                PositionType = PositionType.Manager
            },
            new Employee
            {
                Id = 4,
                EmployeeType = EmployeeType.Contract,
                PositionType = PositionType.NonManager
            }
        };
    }
}

public enum EmployeeType
{
    Permanent, Contract
}
public enum PositionType
{
    Manager, NonManager
}
public enum Brands
{
    APPLE, DELL
}
public enum SystemType
{
    Laptop, Desktop
}

public class Employee
{
    public int Id { get; set; }
    public EmployeeType EmployeeType { get; set; }
    public PositionType PositionType { get; set; }

    public string ComputerType { get; set; }
}

public interface IBrand
{
    string GetBrand();
}
public interface ISystemType
{
    string GetSystemType();
}
public class MAC : IBrand
{
    public string GetBrand()
    {
        return Brands.APPLE.ToString();
    }
}
public class DELL : IBrand
{
    public string GetBrand()
    {
        return Brands.DELL.ToString();
    }
}
public class Laptop : ISystemType
{
    public string GetSystemType()
    {
        return SystemType.Laptop.ToString();
    }
}
public class Desktop : ISystemType
{
    public string GetSystemType()
    {
        return SystemType.Desktop.ToString();
    }
}

public interface IComputerFactory
{
    IBrand Brand();
    ISystemType SystemType();
}

public class MACFactory : IComputerFactory
{
    public IBrand Brand()
    {
        return new MAC();
    }

    public virtual ISystemType SystemType()
    {
        return new Desktop();
    }
}
public class MACLaptopFactory : MACFactory
{
    public override ISystemType SystemType()
    {
        return new Laptop();
    }
}

public class DELLFactory : IComputerFactory
{
    public IBrand Brand()
    {
        return new DELL();
    }

    public virtual ISystemType SystemType()
    {
        return new Desktop();
    }
}
public class DELLLaptopFactory : DELLFactory
{
    public override ISystemType SystemType()
    {
        return new Laptop();
    }
}

public class EmployeeSystemFactory
{
    public IComputerFactory Create(Employee employee)
    {
        IComputerFactory returnValue;

        if (employee.EmployeeType == EmployeeType.Permanent)
        {
            if (employee.PositionType == PositionType.Manager)
            {
                returnValue = new MACLaptopFactory();
            }
            else
            {
                returnValue = new MACFactory();
            }
        }
        else
        {
            if (employee.PositionType == PositionType.Manager)
            {
                returnValue = new DELLLaptopFactory();
            }
            else
            {
                returnValue = new DELLFactory();
            }
        }

        return returnValue;
    }
}