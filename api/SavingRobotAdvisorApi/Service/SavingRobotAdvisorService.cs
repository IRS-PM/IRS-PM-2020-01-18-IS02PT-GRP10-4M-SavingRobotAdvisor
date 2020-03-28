using System.Collections.Generic;
using SavingRobotAdvisorApi.Models;
using SavingRobotAdvisorApi.Common;
using System;

namespace SavingRobotAdvisorApi.Service
{
    public class SavingRobotAdvisorService{
        public OptimalResult GetOptimalResult(decimal monthlyIncome, decimal savingBalance, decimal monthlyCreditCardSpendingAmount)
        {
            OptimalResult optimalResult = null;

            List<CalculationResult> results = new List<CalculationResult>();

            foreach (Bank bankName in Enum.GetValues(typeof(Bank)))
            {
                if(bankName != Bank.Unkonwn)
                {
                    results.Add(CalculationFactory.GetCalculationResult(bankName, monthlyIncome, savingBalance, monthlyCreditCardSpendingAmount));
                }
            }
            
            results.Sort((x,y) => x.TotalSavingAmount.CompareTo(y.TotalSavingAmount));
            
            if(results.Count>0)
            {
                optimalResult = new OptimalResult()
                {
                    bank = results[0].BankName.GetDescription(),
                    account = results[0].SavingAccountType.GetDescription(),
                    card = results[0].CreditCardType.GetDescription(),
                    interest = Math.Round(results[0].InterestResult.InterestAmount, 2, MidpointRounding.ToEven),
                    interest_rate = Math.Round(results[0].InterestResult.InterestRate, 2, MidpointRounding.ToEven),
                    rebate = Math.Round(results[0].RebateResult.RebateAmount, 2, MidpointRounding.ToEven),
                    rebate_rate = Math.Round(results[0].RebateResult.RebateRate, 2, MidpointRounding.ToEven)
                };
            }
            
            return optimalResult;
        }
    }
}
