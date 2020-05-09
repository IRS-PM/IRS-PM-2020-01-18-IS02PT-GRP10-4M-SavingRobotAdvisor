using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.sc.com/sg/credit-cards/unlimited-cashback-credit-card/#accordian-terms-conditions
    public class SCCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            rebate = monthlySpending.TotalAmount * 1.50m/100 * duration;

            if(monthlySpending.TotalAmount>0)
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