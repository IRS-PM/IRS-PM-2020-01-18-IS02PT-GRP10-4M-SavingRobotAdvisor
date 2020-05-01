using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.cimbbank.com.sg/en/personal/products/cards/credit-cards/cimb-visa-signature.html
    //https://www.cimbbank.com.sg/content/dam/cimbsingapore/personal/cards/terms-and-conditions/tnc-vs-card.pdf
    public class CIMBCreditCardCalculator : ICalculator<RebateResult>
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
            decimal cardRebateCapAmount = 20;
            decimal accountRebateCapAmount = 100;

            /* 
                Valid Category:
                Beauty and Wellness
                Online Shopping
                Grocery
                Pet Shops and Veterinary Services
                Cruise
            */
            if(monthlySpending.TotalAmount > ruleMinimumSpend)
            {
                monthlyDiningSpend = monthlySpending.DiningPercent/100m * monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.2m/100);

                monthlyGrocerySpend = monthlySpending.GroceryPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 10m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPetrolSpend = monthlySpending.PetrolPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.2m/100);

                monthlyPublicTransportSpend = monthlySpending.PublicTransportPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.2m/100);

                monthlyTelcoSpend = monthlySpending.TelcoPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.2m/100);

                monthlyTravelSpend = monthlySpending.TravelPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.2m/100);

                if(monthlyRebate>accountRebateCapAmount)
                    monthlyRebate = accountRebateCapAmount;
                    
                rebate = monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount >= 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
            {
                rebate = monthlySpending.TotalAmount * 0.20m/100 * duration;
            }

            if(monthlySpending.TotalAmount > 0)
            {
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}