using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.citibank.com.sg/gcb/credit_cards/dividend-card.htm
    public class CitibankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 888;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount>=ruleMinimumSpend)
            {
                decimal monthlyRebate = monthlyCreditCardSpendingAmount * 7.75m/100;
                if(monthlyRebate > 75)
                    monthlyRebate = 75;
                rebate =  monthlyRebate * duration;
            }
            else if(monthlyCreditCardSpendingAmount > 0)
            {
                rebate = monthlyCreditCardSpendingAmount * 0.20m/100 * duration;
            }

            if(monthlyCreditCardSpendingAmount > 0)
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