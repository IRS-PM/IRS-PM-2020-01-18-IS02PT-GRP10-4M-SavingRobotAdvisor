using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    public class MaybankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 500;
            decimal rebate = 0;
            int duration = 12;

            if(ruleMinimumSpend>=500 && ruleMinimumSpend < 1500)
            {
                rebate = monthlyCreditCardSpendingAmount * 3.30m/100 * duration;
            }
            else if(ruleMinimumSpend >= 1500)
            {
                rebate = monthlyCreditCardSpendingAmount * 5.00m/100 * duration;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;

            return result;
        }
    }

}