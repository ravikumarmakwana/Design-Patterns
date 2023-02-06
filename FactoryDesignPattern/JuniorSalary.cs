

public class JuniorSalary : ISalary
{
    public int CalculateSalary(int factor1, int factor2, int factor3)
    {
        return factor1 + factor2 + factor3 + 1000;
    }
}
