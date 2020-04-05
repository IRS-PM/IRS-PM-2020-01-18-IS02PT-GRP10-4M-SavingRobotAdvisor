using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.uob.com.sg/personal/save/chequeing/one-account.page
    public class UOBInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 500;
            decimal ruleMinimumSalary = 2000;
            decimal interest = 0;
            decimal interestRate = 0;

            if(ruleMinimumSpend <= monthlyCreditCardSpendingAmount && ruleMinimumSalary <= monthlyIncome)
            {
               if (initialDeposit-75000>0)
               {
                   interest += (initialDeposit - 75000) * 0.05m/100;
                   interest += 15000 * 3.88m/100;
                   interest += 15000 * 2.30m/100;
                   interest += 15000 * 2.15m/100;
                   interest += 15000 * 2.00m/100;
                   interest += 15000 * 1.85m/100;
               }
               else if(initialDeposit > 60000 & initialDeposit < 75000)
               {
                   interest += (initialDeposit-60000) * 3.88m/100;
                   interest += 15000 * 2.30m/100;
                   interest += 15000 * 2.15m/100;
                   interest += 15000 * 2.00m/100;
                   interest += 15000 * 1.85m/100;
               }
               else if(initialDeposit > 45000 & initialDeposit <= 60000)
               {
                   interest += (initialDeposit-45000) * 2.30m/100;
                   interest += 15000 * 2.15m/100;
                   interest += 15000 * 2.00m/100;
                   interest += 15000 * 1.85m/100;
               }
               else if(initialDeposit > 30000 & initialDeposit <= 45000)
               {
                   interest += (initialDeposit-30000) * 2.15m/100;
                   interest += 15000 * 2.00m/100;
                   interest += 15000 * 1.85m/100;
               }
               else if(initialDeposit > 15000 & initialDeposit <= 30000)
               {
                   interest += (initialDeposit-15000) * 2.00m/100;
                   interest += 15000 * 1.85m/100;
               }
               else if(initialDeposit < 15000 & initialDeposit > 0)
               {
                   interest += initialDeposit * 1.85m/100;
               }
            }
            else if (ruleMinimumSpend <= monthlyCreditCardSpendingAmount)
            {
               if (initialDeposit > 75000)
               {
                   interest += (initialDeposit-75000) * 0.05m/100;
                   interest += 75000 * 1.50m/100;
               }
               else if(initialDeposit > 0 & initialDeposit <= 75000)
               {
                    interest += initialDeposit * 1.50m/100;
               }
            }

            if(initialDeposit > 0)
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