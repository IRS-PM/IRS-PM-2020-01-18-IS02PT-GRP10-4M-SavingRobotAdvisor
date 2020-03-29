using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.citibank.com.sg/gcb/deposits/mxgn-savacc.htm
    public class CitibankInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal interest = 0;
            decimal interestRate = 0;
            decimal ruleMinimumDeposit = 70000;
            decimal ruleMaximumDeposit = 150000;

            if(initialDeposit>= ruleMinimumDeposit && initialDeposit <= ruleMaximumDeposit)
            {
                interest += initialDeposit * 0.90m/100;
                interest += initialDeposit * 0.60m/100;
            }
            else if (initialDeposit > 0 && (initialDeposit < ruleMinimumDeposit || initialDeposit > ruleMaximumDeposit))
            {
                interest += initialDeposit * 0.05m/100;
            }

            if (initialDeposit > 0)
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