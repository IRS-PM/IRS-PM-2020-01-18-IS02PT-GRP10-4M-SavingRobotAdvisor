using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.cimbbank.com.sg/en/personal/products/cards/credit-cards/cimb-visa-signature.html
    //https://www.cimbbank.com.sg/content/dam/cimbsingapore/personal/cards/terms-and-conditions/tnc-vs-card.pdf
    public class CIMBCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount > ruleMinimumSpend)
            {
                decimal monthlyRebate = monthlyCreditCardSpendingAmount * 10.00m/100;
                if(monthlyRebate>100)
                    monthlyRebate = 100;
                rebate = monthlyRebate * duration;
            }
            else if(monthlyCreditCardSpendingAmount >= 0 && monthlyCreditCardSpendingAmount < ruleMinimumSpend)
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