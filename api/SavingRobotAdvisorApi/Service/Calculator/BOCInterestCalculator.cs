using SavingRobotAdvisorApi.Models;

namespace SavingRobotAdvisorApi.Service
{
    ///Bonus Interest: https://www.bankofchina.com/sg/pbservice/pb1/201611/t20161130_8271280.html
    ///Prevailing Interest: https://www.bankofchina.com/sg/bocinfo/bi3/201002/t20100207_961728.html
    public class BOCInterestCalculator : ICalculator<InterestResult>
    {
        public InterestResult Calculate(decimal monthlyIncome, decimal initialDeposit, MonthlySpending monthlySpending)
        {
            #region Local Variables
            decimal monthlyFallBelowFee = 3;
            decimal ruleMinimumSpend = 500;
            decimal ruleMaximumSpend = 1500;
            decimal ruleMinimumSalary = 2000;
            decimal ruleMaximumSalary = 6000;
            decimal interest = 0;
            decimal interestRate = 0;
            int duration = 12;

            //Prevailing Interest Rules
            decimal ruleBaseInterestRate1 = 0.250m;
            decimal ruleBaseInterestRate2 = 0.275m;
            decimal ruleBaseInterestRate2MiniAmount = 5000m;
            decimal ruleBaseInterestRate3 = 0.350m;
            decimal ruleBaseInterestRate3MiniAmount = 20000m;
            decimal ruleBaseInterestRate4 = 0.400m;
            decimal ruleBaseInterestRate4MiniAmount = 50000m;
            decimal ruleBaseInterestRate5 = 0.475m;
            decimal ruleBaseInterestRate5MiniAmount = 10000m;
            #endregion

            #region Previailing Interest Calculation

            if (initialDeposit > 0 && initialDeposit < ruleBaseInterestRate2MiniAmount)
            {
                interest += initialDeposit * ruleBaseInterestRate1 / 100;
            }
            else if (initialDeposit >= ruleBaseInterestRate2MiniAmount && initialDeposit < ruleBaseInterestRate3MiniAmount)
            {
                interest += initialDeposit * ruleBaseInterestRate2 / 100;
            }
            else if (initialDeposit >= ruleBaseInterestRate3MiniAmount && initialDeposit < ruleBaseInterestRate4MiniAmount)
            {
                interest += initialDeposit * ruleBaseInterestRate3 / 100;
            }
            else if (initialDeposit >= ruleBaseInterestRate4MiniAmount && initialDeposit < ruleBaseInterestRate5MiniAmount)
            {
                interest += initialDeposit * ruleBaseInterestRate4 / 100;
            }
            else if (initialDeposit >= ruleBaseInterestRate5MiniAmount)
            {
                interest += initialDeposit * ruleBaseInterestRate5 / 100;
            }
            #endregion

            #region Bonus Interest Calculation

            //A minimum monthly average effective balance of S$1,500 is required to enjoy bonus interests.
            if (initialDeposit >= 1500)
            {
                //Card Spend Bonus Interest
                if (ruleMinimumSpend <= monthlySpending.TotalAmount && monthlySpending.TotalAmount < ruleMaximumSpend)
                {
                    if (initialDeposit > 0 && initialDeposit < 60000)
                        interest += initialDeposit * 0.80m / 100;
                    else if (initialDeposit > 60000)
                    {
                        interest += 60000 * 0.80m / 100;
                        interest += (initialDeposit - 60000) * 1.00m / 100;
                    }

                }
                else if (monthlySpending.TotalAmount > ruleMaximumSpend)
                {
                    if (initialDeposit > 0 && initialDeposit < 60000)
                        interest += initialDeposit * 1.60m / 100;
                    else if (initialDeposit > 60000)
                    {
                        interest += 60000 * 1.60m / 100;
                        interest += (initialDeposit - 60000) * 1.00m / 100;
                    }
                }

                //Salary Crediting Bonus Interest
                if (ruleMinimumSalary <= monthlyIncome && monthlyIncome < ruleMaximumSalary)
                {
                    if (initialDeposit > 0 && initialDeposit < 60000)
                        interest += initialDeposit * 0.80m / 100;
                    else if (initialDeposit > 60000)
                    {
                        interest += 60000 * 0.80m / 100;
                        interest += (initialDeposit - 60000) * 1.00m / 100;
                    }
                }
                else if (monthlyIncome > ruleMaximumSalary)
                {
                    if (initialDeposit > 0 && initialDeposit < 60000)
                        interest += initialDeposit * 1.20m / 100;
                    else if (initialDeposit > 60000)
                    {
                        interest += 60000 * 1.20m / 100;
                        interest += (initialDeposit - 60000) * 1.00m / 100;
                    }
                }

                /*
                Payment Bonus Interest - Assume user will meet the requirements in order to maximumize the interest.
                Enjoy 0.35% p.a. Payment bonus interest when you successfully complete 3 bill payments of 
                at least S$30 each via GIRO or BOC Internet Banking/BOC Mobile Banking Bill Payment function.
                */
                if (initialDeposit > 0 && initialDeposit < 60000)
                {
                    interest += initialDeposit * 0.35m / 100;
                }
                else if (initialDeposit > 60000)
                {
                    interest += 60000 * 0.35m / 100;
                }
            }

            /*
            Extra Savings Interest - Enjoy 0.60% p.a. Extra bonus interest when you have fulfilled at least 
            one of the requirements for either Card Spend, Salary Crediting or Payment bonus interest.
            */
            if (initialDeposit > 60000 && initialDeposit < 1000000)
            {
                interest += (initialDeposit - 60000) * 0.60m / 100;
            }
            #endregion

            if (initialDeposit < 1500)
            {
                interest -= monthlyFallBelowFee * duration;
            }

            if(initialDeposit>0 && interest > 0)
            {
                interestRate = interest / initialDeposit * 100;
            }

            var result = new InterestResult();
            result.InterestAmount = interest;
            result.InterestRate = interestRate;

            return result;
        }
    }

}