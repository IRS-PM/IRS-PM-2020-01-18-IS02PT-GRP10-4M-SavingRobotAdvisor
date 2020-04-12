using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Interest Table: https://www.citibank.com.sg/gcb/deposits/mxgn-savacc.htm
    //https://www.citibank.com.sg/global_docs/pdf/MaxiGain_TC_2_Dec_2019.pdf
    public class CitibankInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, decimal monthlyCreditCardSpendingAmount)
        {
            decimal interest = 0;
            decimal interestRate = 0;
            decimal ruleMinimumDeposit = 70000;
            decimal ruleMaximumDeposit = 150000;
            decimal duration = 12;

            //Base Interest between 75K and 150K
            if(initialDeposit>= ruleMinimumDeposit && initialDeposit <= ruleMaximumDeposit)
            {
                interest += initialDeposit * 0.90m/100;
            }
            else if (initialDeposit > ruleMaximumDeposit) //Base Interest above 150K
            {
                interest += (initialDeposit - ruleMaximumDeposit) * 0.05m/100;
            }

            //Bonus Interest
            if(initialDeposit > 0 && initialDeposit <= ruleMaximumDeposit)
            {
                decimal bonusInterestRate = 0.05m;
                for(int i =0 ; i< duration; i++)
                {
                    interest += initialDeposit * bonusInterestRate * 30/365/100;
                    if(bonusInterestRate<=0.6m)
                        bonusInterestRate += 0.05m;
                }
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