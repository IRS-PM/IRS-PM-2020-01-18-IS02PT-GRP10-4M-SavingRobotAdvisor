using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.maybank2u.com.sg/en/personal/cards/credit/maybank-family-and-friends-mastercard.page
    public class MaybankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpendTier1 = 800;
            decimal ruleMinimumSpendTier2 = 500;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount>= ruleMinimumSpendTier1)
            {
                decimal monthlyRebate = monthlyCreditCardSpendingAmount * 8.00m/100;
                if(monthlyRebate>80)
                    monthlyRebate = 80;
                rebate = monthlyRebate * duration;
            }
            else if(monthlyCreditCardSpendingAmount < ruleMinimumSpendTier1 && monthlyCreditCardSpendingAmount > ruleMinimumSpendTier2)
            {
                rebate = monthlyCreditCardSpendingAmount * 5.00m/100 * duration;
            }
            else if (monthlyCreditCardSpendingAmount > 0 && monthlyCreditCardSpendingAmount < ruleMinimumSpendTier2)
            {
                rebate = monthlyCreditCardSpendingAmount * 0.30m/100 * duration;
            }

            if (monthlyCreditCardSpendingAmount > 0)
            {
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}