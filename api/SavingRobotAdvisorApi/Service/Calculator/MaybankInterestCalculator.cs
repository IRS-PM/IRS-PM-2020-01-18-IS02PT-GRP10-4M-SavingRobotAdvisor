using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.maybank2u.com.sg/en/personal/saveup/save-up-programme.page
    public class MaybankInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal monthlyFallBelowFee = 2;
            decimal ruleMinimumSpend = 500;
            decimal ruleMinimumSalary = 2000;
            decimal interest = 0;
            decimal interestRate = 0;
            int duration = 12;

            if(ruleMinimumSpend <= monthlySpending.TotalAmount && ruleMinimumSalary <= monthlyIncome)
            {
               if (initialDeposit>50000)
               {
                   interest += initialDeposit * 0.3125m/100;
                   interest += 50000 * 0.8m/100;
               }
               else if(initialDeposit > 0 & initialDeposit < 50000)
               {
                    interest += initialDeposit * 0.3125m/100;
               }
            }
            else if ((ruleMinimumSpend > monthlySpending.TotalAmount && monthlySpending.TotalAmount > 0) || (ruleMinimumSalary > monthlyIncome && monthlyIncome > 0))
            {
                if (initialDeposit>3700 && initialDeposit <=50000)
               {
                   interest += 3700 * 0.1875m/100;
                   interest += (initialDeposit-3700) * 0.2500m/100;
               }
               else if(initialDeposit < 3700)
               {
                    interest += initialDeposit * 0.1875m/100;
               }
            }

            if(initialDeposit < 500)
            {
                interest -= monthlyFallBelowFee * duration;
            }

            if(initialDeposit > 0 && interest > 0)
            {
                interestRate = interest/initialDeposit*100;
            }

            var result = new InterestResult();
            result.InterestAmount = interest;
            result.InterestRate = interestRate;

            return result;
        }
    }

}