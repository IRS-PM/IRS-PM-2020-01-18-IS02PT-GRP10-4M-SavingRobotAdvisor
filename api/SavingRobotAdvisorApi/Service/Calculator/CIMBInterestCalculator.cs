using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Calculation Table: https://www.cimbbank.com.sg/en/personal/products/accounts/savings-accounts/cimb-fastsaver-account.html
    //Charges: https://www.cimbbank.com.sg/en/personal/support/help-and-support/rates-and-charges.html?c=fees-and-charges&n=accounts
    public class CIMBInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            decimal interest = 0;
            decimal interestRate = 0;     

            if (initialDeposit > 100000)
            {
                interest += (initialDeposit - 100000) * 0.60m/100;
                interest += 25000 * 1.80m/100;
                interest += 25000 * 1.50m/100;
                interest += 50000 * 1.00m/100;
            }
            else if(initialDeposit > 75000 & initialDeposit <= 100000)
            {
                interest += (initialDeposit-75000) * 1.80m/100;
                interest += 25000 * 1.50m/100;
                interest += 50000 * 1.00m/100;
            }
            else if(initialDeposit > 50000 & initialDeposit <= 75000)
            {
                interest += (initialDeposit-50000) * 1.50m/100;
                interest += 50000 * 1.00m/100;
            }
            else if(initialDeposit >= 1000 && initialDeposit <= 50000) 
            {
                    //Maintain a minimum deposit of S$1,000 to enjoy an interest rate of up to 1.80% p.a.*.
                interest += initialDeposit * 1.00m/100;
            }

            if(initialDeposit > 0)
                interestRate = interest/initialDeposit*100;

            var result = new InterestResult();
            result.InterestAmount = interest;
            result.InterestRate = interestRate;

            return result;
        }
    }

}