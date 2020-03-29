using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Calculation Table: https://www.ocbc.com/personal-banking/deposits/360-savings-account
    public class OCBCInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 500;
            decimal ruleMinimumSalary = 2000;
            decimal interest = 0;

            if(ruleMinimumSalary <= monthlyIncome)
            {
               if(initialDeposit >= 200000)
               {
                   interest += initialDeposit * 1.00m/100;
                   interest += (200000 - 70000) * 0.05m/100;
                   interest += 70000 * 2.00m/100;
               }
               else if (initialDeposit-70000>0 && initialDeposit < 200000)
               {
                   interest += (initialDeposit - 70000) * 0.05m/100;
                   interest += 70000 * 2.00m/100;
               }
            }

            if (ruleMinimumSpend <= monthlyCreditCardSpendingAmount)
            {
                interest += (monthlyCreditCardSpendingAmount * 12) * 0.6m/100;
            }

            var result = new InterestResult();
            result.InterestAmount = interest;
            result.InterestRate = interest/initialDeposit*100;

            return result;
        }
    }

}