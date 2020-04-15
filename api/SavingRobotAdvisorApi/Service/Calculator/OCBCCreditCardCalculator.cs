using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.ocbc.com/personal-banking/cards/365-cashback-credit-card
    //https://www.ocbc.com/iwov-resources/sg/ocbc/personal/pdf/cards/365-terms-and-conditions-1-oct-2019.pdf
    public class OCBCCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 800;
            decimal rebate = 0;
            decimal rebateRate = 0;
            int duration = 12;
            decimal averageRebateRate = (6m+3m+3m+3m+3m+3m+5m+0.3m)/8;

            if(monthlySpending.TotalAmount>=ruleMinimumSpend)
            {   
                decimal monthlyRebateAmount = monthlySpending.TotalAmount * averageRebateRate/100;
                if(monthlyRebateAmount > 80)
                    monthlyRebateAmount = 80;
                rebate = monthlyRebateAmount * duration;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }
            else if(monthlySpending.TotalAmount > 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
            {
                rebate = monthlySpending.TotalAmount * duration * 0.03m/100;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}