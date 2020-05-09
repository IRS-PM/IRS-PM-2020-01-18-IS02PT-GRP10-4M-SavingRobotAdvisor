using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table:https://cloud.bankofchina.com/sgp/boc_cc/media/documents/Terms_and_Conditions_Governing_BOC_Family_Credit_Card_Cash_Rebate_Programme.pdf
    public class BOCCreditCardCalculator : ICalculator<RebateResult>
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
            decimal cardRebateCapAmount = 25;

            /*
                Valid Category:
                Dining and Movies
                Public Transport Transactions
                Supermarket, Online purchases and Hospital
            */
            if(monthlySpending.TotalAmount >=ruleMinimumSpend)
            {
                monthlyDiningSpend = monthlySpending.DiningPercent/100m * monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 10m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyGrocerySpend = monthlySpending.GroceryPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPetrolSpend = monthlySpending.PetrolPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.30m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPublicTransportSpend = monthlySpending.PublicTransportPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 3m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyTelcoSpend = monthlySpending.TelcoPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.30m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyTravelSpend = monthlySpending.TravelPercent/100m *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.30m/100).GetRebateByCap(cardRebateCapAmount);

                rebate = monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount >= 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
            {
                rebate = monthlySpending.TotalAmount * 0.30m/100 * duration;
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