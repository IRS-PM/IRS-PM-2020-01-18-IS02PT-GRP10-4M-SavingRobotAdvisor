using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

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

            decimal monthlyDiningSpend = 0;
            decimal monthlyGrocerySpend = 0;
            decimal monthlyPetrolSpend = 0;
            decimal monthlyPublicTransportSpend = 0;
            decimal monthlyTelcoSpend = 0;
            decimal monthlyTravelSpend = 0;
            decimal monthlyRebate = 0;
            decimal accountRebateCapAmount = 80;

            if(monthlySpending.TotalAmount>=ruleMinimumSpend)
            {              
                monthlyDiningSpend = monthlySpending.DiningPercent/100m * monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 6m/100);

                monthlyGrocerySpend = monthlySpending.GroceryPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100);

                monthlyPetrolSpend = monthlySpending.PetrolPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 5m/100);

                monthlyPublicTransportSpend = monthlySpending.PublicTransportPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100);

                monthlyTelcoSpend = monthlySpending.TelcoPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100);

                monthlyTravelSpend = monthlySpending.TravelPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100);
          
                if(monthlyRebate > accountRebateCapAmount)
                    monthlyRebate = accountRebateCapAmount;
                rebate = monthlyRebate * duration;
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