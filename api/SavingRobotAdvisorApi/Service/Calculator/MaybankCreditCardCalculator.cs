using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.maybank2u.com.sg/en/personal/cards/credit/maybank-family-and-friends-mastercard.page
    public class MaybankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpendTier1 = 800;
            decimal ruleMinimumSpendTier2 = 500;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlySpending.TotalAmount>= ruleMinimumSpendTier1)
            {
                decimal monthlyRebate = monthlySpending.TotalAmount * 8.00m/100;
                if(monthlyRebate>80)
                    monthlyRebate = 80;
                rebate = monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount < ruleMinimumSpendTier1 && monthlySpending.TotalAmount > ruleMinimumSpendTier2)
            {
                rebate = monthlySpending.TotalAmount * 5.00m/100 * duration;
            }
            else if (monthlySpending.TotalAmount > 0 && monthlySpending.TotalAmount < ruleMinimumSpendTier2)
            {
                rebate = monthlySpending.TotalAmount * 0.30m/100 * duration;
            }

            if (monthlySpending.TotalAmount > 0)
            {
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}