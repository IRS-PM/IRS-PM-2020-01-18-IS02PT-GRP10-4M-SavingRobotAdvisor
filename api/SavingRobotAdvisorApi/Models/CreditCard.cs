using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class CreditCard : Account<RebateResult>
    {
        public decimal MonthlyIncome { get; set;}
        public decimal InitialDeposit {get; set;}
        public MonthlySpending MonthlySpending {get; set;}


        public CreditCard(Bank bankName,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             MonthlySpending monthlySpending,
                             ICalculator<RebateResult> rebateCalculator):base(rebateCalculator)
        {
            BankName = bankName;
            MonthlyIncome = monthlyIncome;
            InitialDeposit = initialDeposit;
            MonthlySpending  = monthlySpending;
        }

        public override RebateResult Calculate()
        {
            return Calculator.Calculate(MonthlyIncome, InitialDeposit, MonthlySpending);
        }
    }
}