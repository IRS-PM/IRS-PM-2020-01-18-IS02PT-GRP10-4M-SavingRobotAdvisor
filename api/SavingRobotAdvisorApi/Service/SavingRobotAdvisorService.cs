using System.Collections.Generic;
using SavingRobotAdvisorApi.Models;
using SavingRobotAdvisorApi.Common;
using System;

namespace SavingRobotAdvisorApi.Service
{
    public class SavingRobotAdvisorService{
        public List<OptimalResult> GetOptimalResult(decimal monthlyIncome, decimal savingBalance, decimal monthlyCreditCardSpendingAmount)
        {
            List<OptimalResult> optimalResults = new List<OptimalResult>();
            List<CalculationResult> results = new List<CalculationResult>();

            foreach (Bank bankName in Enum.GetValues(typeof(Bank)))
            {
                if(bankName != Bank.Unkonwn)
                {
                    results.Add(CalculationFactory.GetCalculationResult(bankName, monthlyIncome, savingBalance, monthlyCreditCardSpendingAmount));
                }
            }
            
            results.Sort((x,y) => x.TotalSavingAmount.CompareTo(y.TotalSavingAmount));
            
            foreach(CalculationResult result in results)
            {
                optimalResults.Add(new OptimalResult()
                {
                    bank = result.BankName.GetDescription(),
                    account = result.SavingAccountType.GetDescription(),
                    card = result.CreditCardType.GetDescription(),
                    interest = Math.Round(result.InterestResult.InterestAmount, 2, MidpointRounding.ToEven),
                    interest_rate = Math.Round(result.InterestResult.InterestRate, 2, MidpointRounding.ToEven),
                    rebate = Math.Round(result.RebateResult.RebateAmount, 2, MidpointRounding.ToEven),
                    rebate_rate = Math.Round(result.RebateResult.RebateRate, 2, MidpointRounding.ToEven)
                });
            }
            
            return optimalResults;
        }
    }
}
