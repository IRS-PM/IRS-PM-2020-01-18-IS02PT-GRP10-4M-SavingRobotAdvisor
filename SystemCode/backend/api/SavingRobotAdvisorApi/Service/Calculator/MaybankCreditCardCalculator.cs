using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.maybank2u.com.sg/en/personal/cards/credit/maybank-family-and-friends-mastercard.page
    public class MaybankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpendTier1 = 500;
            decimal ruleMinimumSpendTier2 = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlySpending.TotalAmount>= ruleMinimumSpendTier2)
            {
                decimal monthlyRebate = monthlySpending.TotalAmount * 8m/100;
                if(monthlyRebate>80)
                    monthlyRebate = 80 + (monthlySpending.TotalAmount-80m/8/100)*0.3m/100;
                rebate = monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount < ruleMinimumSpendTier2 && monthlySpending.TotalAmount > ruleMinimumSpendTier1)
            {
                rebate = monthlySpending.TotalAmount * 5m/100 * duration;
            }
            else if (monthlySpending.TotalAmount > 0 && monthlySpending.TotalAmount < ruleMinimumSpendTier1)
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