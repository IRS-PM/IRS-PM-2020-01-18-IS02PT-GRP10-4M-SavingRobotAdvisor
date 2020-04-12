using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.posb.com.sg/personal/cards/credit-cards/posb-everyday-card
    //https://www.posb.com.sg/iwov-resources/pdf/cards/credit-cards/everydaycard_tnc.pdf
    public class DBSCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 0;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;
            decimal averageRebateRate = (5m+1m+0.3m)/3;

            if(ruleMinimumSpend < monthlyCreditCardSpendingAmount)
            {
                decimal monthlyRebateAmount = monthlyCreditCardSpendingAmount * averageRebateRate/100;
                if(monthlyRebateAmount>50)
                    monthlyRebateAmount = 50;
                rebate = monthlyRebateAmount*duration;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}