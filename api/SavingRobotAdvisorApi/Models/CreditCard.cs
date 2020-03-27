using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class CreditCard : Account<RebateResult>
    {
        public CreditCardType CreditCardType {get; set;}
        public decimal MonthlyIncome { get; set;}
        public decimal InitialDeposit {get; set;}
        public decimal MonthlyCreditCardSpendingAmount {get; set;}
        public CreditCard(Bank bankName,
                             CreditCardType creditCardType,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             decimal monthlyCreditCardSpendingAmount,
                             ICalculator<RebateResult> rebateCalculator):base(rebateCalculator)
        {
            BankName = bankName;
            CreditCardType = creditCardType;
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