using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.posb.com.sg/personal/cards/credit-cards/posb-everyday-card
    public class DBSCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 0;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(ruleMinimumSpend < monthlyCreditCardSpendingAmount)
            {
                decimal averageRebateRate = (5m+3m+1m)/3;
                rebate = monthlyCreditCardSpendingAmount*duration * averageRebateRate/100;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}