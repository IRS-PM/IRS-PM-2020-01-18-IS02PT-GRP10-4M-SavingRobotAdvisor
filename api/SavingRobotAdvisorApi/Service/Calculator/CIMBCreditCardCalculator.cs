using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.cimbbank.com.sg/en/personal/products/cards/credit-cards/cimb-visa-signature.html
    //https://www.cimbbank.com.sg/content/dam/cimbsingapore/personal/cards/terms-and-conditions/tnc-vs-card.pdf
    public class CIMBCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlySpending.TotalAmount > ruleMinimumSpend)
            {
                decimal monthlyRebate = monthlySpending.TotalAmount * 10.00m/100;
                if(monthlyRebate>100)
                    monthlyRebate = 100;
                rebate = monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount >= 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
            {
                rebate = monthlySpending.TotalAmount * 0.20m/100 * duration;
            }

            if(monthlySpending.TotalAmount > 0)
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