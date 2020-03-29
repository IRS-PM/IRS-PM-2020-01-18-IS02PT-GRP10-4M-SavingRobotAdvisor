using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.dbs.com.sg/personal/rates-online/multiplier-account.page
    public class DBSInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal ruleMinimumTransaction = 2000;
            decimal currentTransaction = monthlyIncome + monthlyCreditCardSpendingAmount;
            decimal interest = 0;
            decimal interestRate = 0;

            if(currentTransaction < ruleMinimumTransaction)
            {
                interest = initialDeposit * 0.05m/100;
            }
            else if (currentTransaction >= ruleMinimumTransaction && currentTransaction < 2500)
            {
                if(initialDeposit>25000)
                {
                    interest += 25000 * 1.55m/100;
                    interest += (initialDeposit - 25000) * 0.05m/100;
                }
                else if(initialDeposit <= 25000 && initialDeposit > 0)
                {
                    interest = initialDeposit * 1.55m/100;
                }
            }
            else if (currentTransaction >= 2500 && currentTransaction < 5000)
            {
               if(initialDeposit>25000)
                {
                    interest += 25000 * 1.85m/100;
                    interest += (initialDeposit - 25000) * 0.05m/100;
                }
                else if(initialDeposit <= 25000 && initialDeposit > 0)
                {
                    interest = initialDeposit * 1.85m/100;
                }
            }
            else if (currentTransaction >= 5000 && currentTransaction < 15000)
            {
               if(initialDeposit>25000)
                {
                    interest += 25000 * 1.90m/100;
                    interest += (initialDeposit - 25000) * 0.05m/100;
                }
                else if(initialDeposit <= 25000 && initialDeposit > 0)
                {
                    interest = initialDeposit * 1.90m/100;
                }
            }
            else if (currentTransaction >= 15000 && currentTransaction < 30000)
            {
               if(initialDeposit>25000)
                {
                    interest += 25000 * 2.00m/100;
                    interest += (initialDeposit - 25000) * 0.05m/100;
                }
                else if(initialDeposit <= 25000 && initialDeposit > 0)
                {
                    interest = initialDeposit * 2.00m/100;
                }
            }
            else if (currentTransaction >= 30000)
            {
               if(initialDeposit>25000)
                {
                    interest += 25000 * 2.08m/100;
                    interest += (initialDeposit - 25000) * 0.05m/100;
                }
                else if(initialDeposit <= 25000 && initialDeposit > 0)
                {
                    interest = initialDeposit * 2.08m/100;
                }
            }

            if(initialDeposit>0)
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