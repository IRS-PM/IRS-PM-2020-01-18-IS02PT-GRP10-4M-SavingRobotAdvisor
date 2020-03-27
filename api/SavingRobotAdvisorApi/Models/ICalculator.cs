namespace SavingRobotAdvisorApi.Models
{
    public interface ICalculator<T>
    {
        T Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount);
    }
}