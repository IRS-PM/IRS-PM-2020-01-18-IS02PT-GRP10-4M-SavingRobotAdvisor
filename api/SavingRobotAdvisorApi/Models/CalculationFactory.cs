using SavingRobotAdvisorApi.Common;
using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Models
{
    public class CalculationFactory
    {
        public static CalculationResult GetCalculationResult(BankInfo bankInfo, 
                                                        decimal monthlyIncome,
                                                        decimal initialDeposit,
                                                        decimal monthlyCreditCardSpendingAmount)
        {
            CalculationResult calculationResult = new CalculationResult();
            decimal totalSavingAmount = 0;
            switch(bankInfo.BankName)
            {
                case Bank.UOB:
                    SavingAccount savingAccount = new SavingAccount(Bank.UOB, SavingAccountType.UOBONE, monthlyIncome, initialDeposit, monthlyCreditCardSpendingAmount, new UOBOneInterestCalculator());
                    InterestResult saving = savingAccount.Calculate();
                    CreditCard creditCardAccount = new CreditCard(Bank.UOB, CreditCardType.Everyday, monthlyIncome, initialDeposit, monthlyCreditCardSpendingAmount, new UOBOneCreditCardCalculator());
                    RebateResult rebate = creditCardAccount.Calculate();
                    totalSavingAmount = saving.InterestAmount + rebate.RebateAmount;
                    calculationResult.CombineCalculationResult(bankInfo, saving, rebate, totalSavingAmount);
                    break;
                default:
                break;
            }

            return calculationResult;
        }

    }

}