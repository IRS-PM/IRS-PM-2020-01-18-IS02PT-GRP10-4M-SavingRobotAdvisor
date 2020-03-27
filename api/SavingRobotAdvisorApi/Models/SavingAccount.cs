using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class SavingAccount : Account<InterestResult>
    {
        public SavingAccountType SavingAccountType {get; set;}
        public decimal MonthlyIncome { get; set;}
        public decimal InitialDeposit {get; set;}
        public decimal MonthlyCreditCardSpendingAmount {get; set;}
        public SavingAccount(Bank bankName,
                             SavingAccountType savingAccountType,
                             decimal monthlyIncome,
                             decimal initialDeposit,
                             decimal monthlyCreditCardSpendingAmount,
                             ICalculator<InterestResult> interestCalculator):base(interestCalculator)
        {
            BankName = bankName;
            SavingAccountType = savingAccountType;
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