using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.bankofchina.com/sg/pbservice/pb1/201611/t20161130_8271280.html
    public class BOCInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumSpend = 500;
            decimal ruleMaximumSpend = 1500;
            decimal ruleMinimumSalary = 2000;
            decimal ruleMaximumSalary = 6000;
            decimal interest = 0;
            decimal interestRate = 0;

            if(ruleMinimumSpend <= monthlyCreditCardSpendingAmount && monthlyCreditCardSpendingAmount < ruleMaximumSpend)
            {
                if(initialDeposit > 0 && initialDeposit < 60000)
                    interest += initialDeposit * 0.80m/100;
                else if (initialDeposit > 60000)
                {
                    interest += 60000 * 0.80m/100;
                    interest += (initialDeposit-60000)*1.00m/100;
                }
                    
            }
            else if (monthlyCreditCardSpendingAmount > ruleMaximumSpend)
            {
                if(initialDeposit > 0 && initialDeposit < 60000)
                    interest += initialDeposit * 1.60m/100;
                else if (initialDeposit > 60000)
                {
                    interest += 60000 * 1.60m/100;
                    interest += (initialDeposit-60000)*1.00m/100;
                }       
            }

            if(ruleMinimumSalary <= monthlyIncome && monthlyIncome < ruleMaximumSalary)
            {
                if(initialDeposit > 0 && initialDeposit < 60000)
                    interest += initialDeposit * 0.80m/100;
                else if (initialDeposit > 60000)
                {
                    interest += 60000 * 0.80m/100;
                    interest += (initialDeposit-60000)*1.00m/100;
                }
            }
            else if (monthlyIncome > ruleMaximumSalary)
            {
                if(initialDeposit > 0 && initialDeposit < 60000)
                    interest += initialDeposit * 1.20m/100;
                else if (initialDeposit > 60000)
                {
                    interest += 60000 * 1.20m/100;
                    interest += (initialDeposit-60000)*1.00m/100;
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