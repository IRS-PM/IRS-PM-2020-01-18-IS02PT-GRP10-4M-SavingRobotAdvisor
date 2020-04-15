using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.citibank.com.sg/gcb/credit_cards/dividend-card.htm
    public class CitibankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 888;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlySpending.TotalAmount>=ruleMinimumSpend)
            {
                decimal monthlyRebate = monthlySpending.TotalAmount * 7.75m/100;
                if(monthlyRebate > 75)
                    monthlyRebate = 75;
                rebate =  monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount > 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
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