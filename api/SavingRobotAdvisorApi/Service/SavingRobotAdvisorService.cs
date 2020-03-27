using System.Collections.Generic;
using SavingRobotAdvisorApi.Models;
using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Service
{
    public class SavingRobotAdvisorService{
        private List<BankInfo> bankInfos = null;

        public OptimalResult GetOptimalResult(decimal monthlyIncome, decimal savingBalance, decimal monthlyCreditCardSpendingAmount)
        {
            OptimalResult optimalResult = null;

            bankInfos = new List<BankInfo>();
            bankInfos.Add(new BankInfo(){BankName=Bank.UOB, SavingAccountType=SavingAccountType.UOBONE,CreditCardType=CreditCardType.UOBONE});

            List<CalculationResult> results = new List<CalculationResult>();

            foreach(var bankInfo in bankInfos)
            {
                results.Add(CalculationFactory.GetCalculationResult(bankInfo, monthlyIncome, savingBalance, monthlyCreditCardSpendingAmount));
            }
            
            results.Sort((x,y) => x.TotalSavingAmount.CompareTo(y.TotalSavingAmount));
            
            if(results.Count>0)
            {
                optimalResult = new OptimalResult()
                {
                    bank = results[0].BankInfo.BankName.GetDescription(),
                    account = results[0].BankInfo.SavingAccountType.GetDescription(),
                    card = results[0].BankInfo.CreditCardType.GetDescription(),
                    interest = results[0].InterestResult.InterestAmount,
                    interest_rate = results[0].InterestResult.InterestRate,
                    rebate = results[0].RebateResult.RebateAmount,
                    rebate_rate = results[0].RebateResult.RebateRate
                };
            }

            
            return optimalResult;
        }
    }
}
