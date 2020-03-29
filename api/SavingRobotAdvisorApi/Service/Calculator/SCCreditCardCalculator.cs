using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.sc.com/sg/credit-cards/unlimited-cashback-credit-card/#accordian-terms-conditions
    public class SCCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            rebate = monthlyCreditCardSpendingAmount * 1.50m/100 * duration;

            if(monthlyCreditCardSpendingAmount>0)
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