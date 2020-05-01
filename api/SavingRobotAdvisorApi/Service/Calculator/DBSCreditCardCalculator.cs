using SavingRobotAdvisorApi.Models;
using  SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    //Rebate Table: https://www.posb.com.sg/personal/cards/credit-cards/posb-everyday-card
    //https://www.posb.com.sg/iwov-resources/pdf/cards/credit-cards/everydaycard_tnc.pdf
    public class DBSCreditCardCalculator : ICalculator<RebateResult>
    {
        public RebateResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal ruleMinimumSpend = 0;
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
            decimal cardRebateCapAmount = 40;

            if(ruleMinimumSpend < monthlySpending.TotalAmount)
            {
                monthlyDiningSpend = monthlySpending.DiningPercent * monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * (10+5)/2m/100);

                monthlyGrocerySpend = monthlySpending.GroceryPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 5m/100).GetRebateByCap(cardRebateCapAmount);

                monthlyPetrolSpend = monthlySpending.PetrolPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 6m/100);

                monthlyPublicTransportSpend = monthlySpending.PublicTransportPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.3m/100);

                monthlyTelcoSpend = monthlySpending.TelcoPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.3m/100);

                monthlyTravelSpend = monthlySpending.TravelPercent *  monthlySpending.TotalAmount;
                monthlyRebate += (monthlyDiningSpend * 0.3m/100);


                rebate = monthlyRebate*duration;
                rebateRate = rebate/(monthlySpending.TotalAmount*duration)*100;
            }

            var result = new RebateResult();
            result.RebateAmount = rebate;
            result.RebateRate = rebateRate;

            return result;
        }
    }

}