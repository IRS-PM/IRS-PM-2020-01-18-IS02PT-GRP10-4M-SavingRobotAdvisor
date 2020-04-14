using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class SavingAccount : Account<InterestResult>
    {
        public decimal MonthlyIncome { get; set; }
        public decimal InitialDeposit { get; set; }
        public MonthlySpending MonthlySpending { get; set; }
        public SavingAccount(Bank bankName,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             MonthlySpending monthlySpending,
                             ICalculator<InterestResult> interestCalculator) : base(interestCalculator)
        {
            BankName = bankName;
            MonthlyIncome = monthlyIncome;
            InitialDeposit = initialDeposit;
            MonthlySpending = monthlySpending;
        }

        public override InterestResult Calculate()
        {
            return Calculator.Calculate(MonthlyIncome, InitialDeposit, MonthlySpending);
        }
    }
}