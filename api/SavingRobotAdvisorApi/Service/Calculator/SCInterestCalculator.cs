using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.sc.com/sg/save/current-accounts/bonussaver/
    //https://www.sc.com/sg/terms-and-conditions/bonusaver-product-terms/
    public class SCInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal monthlyFallBelowFee = 5;
            decimal ruleMinimumSpend = 2000;
            decimal ruleMinimumSalary = 3000;
            decimal interest = 0;
            decimal interestRate = 0;
            decimal duration = 12;
            decimal baseInterestRate = 0.1m;

            if(initialDeposit > 0)
            {
                interest += initialDeposit * baseInterestRate;
            }

            if(ruleMinimumSpend <= monthlyCreditCardSpendingAmount && ruleMinimumSalary <= monthlyIncome)
            {
               if (initialDeposit <= 100000 && initialDeposit > 0)
               {
                   interest += initialDeposit* 1.50m/100;
                   interest += initialDeposit* 1.00m/100;
               }
               else if ( initialDeposit > 100000)
               {
                   interest += 100000* 1.50m/100;
                   interest += 100000* 1.00m/100;
                   interest += (initialDeposit - 100000) * 0.05m/100;
               }
            }
            else if (monthlyCreditCardSpendingAmount < ruleMinimumSpend && ruleMinimumSalary <= monthlyIncome)
            {
               if (initialDeposit <= 100000 && initialDeposit > 0)
               {
                   if(monthlyCreditCardSpendingAmount >= 500)
                   {
                     interest += initialDeposit* 0.88m/100;
                   }
                   
                   interest += initialDeposit* 1.00m/100;
               }
               else if ( initialDeposit > 100000)
               {
                   if(monthlyCreditCardSpendingAmount >= 500)
                   {
                     interest += 100000* 0.88m/100;
                   }
                   interest += 100000* 1.00m/100;
                   interest += (initialDeposit - 100000) * 0.05m/100;
               }
            }

            if(initialDeposit < 3000)
            {
                interest -= monthlyFallBelowFee * duration;
            }

            if(initialDeposit > 0 && interest >0)
            {
               interestRate = interest/initialDeposit * 100;
            }            

            var result = new InterestResult();
            result.InterestAmount = interest;
            result.InterestRate = interestRate;

            return result;
        }
    }

}