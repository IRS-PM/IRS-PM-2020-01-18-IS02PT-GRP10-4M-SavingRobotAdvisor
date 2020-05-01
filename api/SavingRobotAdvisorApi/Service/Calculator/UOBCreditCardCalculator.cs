using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.uob.com.sg/personal/cards/credit/one/
    //https://www.uob.com.sg/assets/pdfs/one_card_full_tnc.pdf
    public class UOBCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpendTier1 = 500;
            decimal ruleMinimumSpendTier2 = 1000;
            decimal ruleMinimumSpendTier3 = 2000;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;
            decimal quarterlyRebate = 0;

            if(monthlySpending.TotalAmount >= ruleMinimumSpendTier1 && monthlySpending.TotalAmount < ruleMinimumSpendTier2)
            {
                quarterlyRebate = (monthlySpending.TotalAmount * 3.30m/100 * 3).GetRebateByCap(50);
                rebate = quarterlyRebate*4;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }
            else if (monthlySpending.TotalAmount >= ruleMinimumSpendTier2 && monthlySpending.TotalAmount < ruleMinimumSpendTier3)
            {
                quarterlyRebate = (monthlySpending.TotalAmount * 3.30m/100 * 3).GetRebateByCap(100);
                rebate = quarterlyRebate*4;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }
            else if(monthlySpending.TotalAmount >= ruleMinimumSpendTier3)
            {
                quarterlyRebate = (monthlySpending.TotalAmount * 5m/100 * 3).GetRebateByCap(300);
                rebate = quarterlyRebate*4;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}