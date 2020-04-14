using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Calculation Table: https://www.ocbc.com/personal-banking/deposits/360-savings-account
    //Charge: https://www.ocbc.com/assets/pdf/fees-and-charges-guide-personal-banking-products.pdf
    public class OCBCInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal monthlyFallBelowFee = 2;
            decimal ruleMinimumSpend = 500;
            decimal ruleMinimumSalary = 2000;
            decimal interest = 0;
            decimal interestRate = 0;
            int duration = 12;

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

            if (ruleMinimumSpend <= monthlySpending.TotalAmount)
            {
                interest += (monthlySpending.TotalAmount * 12) * 0.6m/100;
            }

            if(initialDeposit < 3000)
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