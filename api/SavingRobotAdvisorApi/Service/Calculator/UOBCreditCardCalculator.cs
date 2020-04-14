using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.uob.com.sg/personal/cards/credit/one/
    //https://www.uob.com.sg/assets/pdfs/one_card_full_tnc.pdf
    public class UOBCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 500;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;

            if(monthlySpending.TotalAmount >= ruleMinimumSpend && monthlySpending.TotalAmount < 1500)
            {
                rebate = monthlySpending.TotalAmount * 3.30m/100 * duration;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }
            else if(monthlySpending.TotalAmount >= 1500)
            {
                decimal monthlyRebateAmount = monthlySpending.TotalAmount * 5.00m/100;
                if(monthlyRebateAmount>100)
                    monthlyRebateAmount = 100;
                rebate =  monthlyRebateAmount * duration;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}