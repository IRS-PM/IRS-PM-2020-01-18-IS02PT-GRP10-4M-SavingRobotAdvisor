using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class SavingAccount : Account<InterestResult>
    {
        public decimal MonthlyIncome { get; set;}
        public decimal InitialDeposit {get; set;}
        public decimal MonthlyCreditCardSpendingAmount {get; set;}
        public SavingAccount(Bank bankName,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             decimal monthlyCreditCardSpendingAmount,
                             ICalculator<InterestResult> interestCalculator):base(interestCalculator)
        {
            BankName = bankName;
            MonthlyIncome = monthlyIncome;
            InitialDeposit = initialDeposit;
            MonthlyCreditCardSpendingAmount = monthlyCreditCardSpendingAmount;
        }

        public override InterestResult Calculate()
        {
            return Calculator.Calculate(MonthlyIncome, InitialDeposit, MonthlyCreditCardSpendingAmount);
        }
    }
}