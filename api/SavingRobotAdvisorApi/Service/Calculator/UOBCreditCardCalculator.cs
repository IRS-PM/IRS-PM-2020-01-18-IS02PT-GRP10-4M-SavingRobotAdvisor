using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.uob.com.sg/personal/cards/credit/one/
    //https://www.uob.com.sg/assets/pdfs/one_card_full_tnc.pdf
    public class UOBCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 500;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlyCreditCardSpendingAmount >= ruleMinimumSpend && monthlyCreditCardSpendingAmount < 1500)
            {
                rebate = monthlyCreditCardSpendingAmount * 3.30m/100 * duration;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }
            else if(monthlyCreditCardSpendingAmount >= 1500)
            {
                decimal monthlyRebateAmount = monthlyCreditCardSpendingAmount * 5.00m/100;
                if(monthlyRebateAmount>100)
                    monthlyRebateAmount = 100;
                rebate =  monthlyRebateAmount * duration;
                rebateRate = rebate/(monthlyCreditCardSpendingAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}