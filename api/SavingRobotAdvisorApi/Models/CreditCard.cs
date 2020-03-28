using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class CreditCard : Account<RebateResult>
    {
        public decimal MonthlyIncome { get; set;}
        public decimal InitialDeposit {get; set;}
        public decimal MonthlyCreditCardSpendingAmount {get; set;}
        public CreditCard(Bank bankName,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             decimal monthlyCreditCardSpendingAmount,
                             ICalculator<RebateResult> rebateCalculator):base(rebateCalculator)
        {
            BankName = bankName;
            MonthlyIncome = monthlyIncome;
            InitialDeposit = initialDeposit;
            MonthlyCreditCardSpendingAmount = monthlyCreditCardSpendingAmount;
        }

        public override RebateResult Calculate()
        {
            return Calculator.Calculate(MonthlyIncome, InitialDeposit, MonthlyCreditCardSpendingAmount);
        }
    }
}