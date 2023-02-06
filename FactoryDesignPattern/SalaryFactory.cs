public class SalaryFactory
{
    public static ISalary GetSalaryInstance(EmployeeType employeeType)
    {
        switch (employeeType)
        {
            case EmployeeType.Junior:
                return new JuniorSalary();
            case EmployeeType.Senior:
                return new SeniorSalary();
            case EmployeeType.Lead:
                return new LeadSalary();
            case EmployeeType.Manager:
                return new ManagerSalary();
            default:
                return null;
        }
    }
}
