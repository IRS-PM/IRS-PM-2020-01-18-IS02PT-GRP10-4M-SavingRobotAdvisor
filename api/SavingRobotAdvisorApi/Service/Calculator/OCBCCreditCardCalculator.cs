using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.ocbc.com/personal-banking/cards/365-cashback-credit-card
    public class OCBCCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount>=ruleMinimumSpend)
            {
                decimal averageRebateRate = (6m+3m+3m+3m+3m+5m)/6;
                rebate = monthlyCreditCardSpendingAmount*duration * averageRebateRate/100;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }
            else if(monthlyCreditCardSpendingAmount > 0 && monthlyCreditCardSpendingAmount < ruleMinimumSpend)
            {
                rebate = monthlyCreditCardSpendingAmount * duration * 0.03m/100;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}