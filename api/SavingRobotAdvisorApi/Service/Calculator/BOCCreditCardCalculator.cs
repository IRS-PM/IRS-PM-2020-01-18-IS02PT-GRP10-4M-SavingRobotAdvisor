using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table:https://cloud.bankofchina.com/sgp/boc_cc/media/documents/Terms_and_Conditions_Governing_BOC_Family_Credit_Card_Cash_Rebate_Programme.pdf
    public class BOCCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount>=ruleMinimumSpend)
            {
                decimal averageRebateRate = (10+10+5+3+3+3+3+3)/8;
                decimal monthlyRebate = monthlyCreditCardSpendingAmount * averageRebateRate/100;
                if(monthlyRebate > 25 * 8)
                {
                    monthlyRebate = 25 * 8;
                }
                rebate = monthlyRebate * duration;
            }
            else if(monthlyCreditCardSpendingAmount >= 0 && monthlyCreditCardSpendingAmount < ruleMinimumSpend)
            {
                rebate = monthlyCreditCardSpendingAmount * 0.30m/100 * duration;
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