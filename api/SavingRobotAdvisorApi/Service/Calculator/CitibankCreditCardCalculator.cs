using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.citibank.com.sg/gcb/credit_cards/dividend-card.htm
    public class CitibankCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 888;
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

            if(monthlySpending.TotalAmount>=ruleMinimumSpend)
            {
                monthlyDiningSpend = monthlySpending.DiningPercent * monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 8m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyGrocerySpend = monthlySpending.GroceryPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 8m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPetrolSpend = monthlySpending.PetrolPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 8m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPublicTransportSpend = monthlySpending.PublicTransportPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.25m/100);

                monthlyTelcoSpend = monthlySpending.TelcoPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.25m/100);

                monthlyTravelSpend = monthlySpending.TravelPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.25m/100);

                rebate =  monthlyRebate * duration;
            }
            else if(monthlySpending.TotalAmount > 0 && monthlySpending.TotalAmount < ruleMinimumSpend)
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