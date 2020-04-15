using SavingRobotAdvisorApi.Common;
using SavingRobotAdvisorApi.Models;
using System;
using System.Collections.Generic;

namespace SavingRobotAdvisorApi.Service
{
    public class CalculationFactory
    {
        public static CalculationResult GetCalculationResult(Bank bankName, 
                                                        decimal monthlyIncome,
                                                        decimal initialDeposit,
                                                        MonthlySpending monthlySpending)
        {
            CalculationResult calculationResult = new CalculationResult();
            decimal totalSavingAmount = 0;

            if(initialDeposit < 0 || monthlyIncome < 0 || monthlySpending == null 
            || (initialDeposit == 0 && monthlyIncome == 0 && monthlySpending == null)
            || (initialDeposit == 0 && monthlyIncome >0 && monthlySpending == null)
            || bankName == Bank.Unkonwn)
            {
                calculationResult.CombineCalculationResult(bankName, null, null, totalSavingAmount);
            }

            var interestCalculator = (ICalculator<InterestResult>)Activator.CreateInstance(Type.GetType("SavingRobotAdvisorApi.Service." + Enum.GetName(typeof(Bank), bankName) + "InterestCalculator"));
            SavingAccount savingAccount = new SavingAccount(bankName, monthlyIncome, initialDeposit, monthlySpending, interestCalculator);
            InterestResult saving = savingAccount.Calculate();

            var rebateCalculator = (ICalculator<RebateResult>)Activator.CreateInstance(Type.GetType("SavingRobotAdvisorApi.Service." + Enum.GetName(typeof(Bank), bankName) + "CreditCardCalculator"));
            CreditCard creditCardAccount = new CreditCard(bankName, monthlyIncome, initialDeposit, monthlySpending, rebateCalculator);
            RebateResult rebate = creditCardAccount.Calculate();
            totalSavingAmount = saving.InterestAmount + rebate.RebateAmount;
            calculationResult.CombineCalculationResult(bankName, saving, rebate, totalSavingAmount);

            return calculationResult;
        }
    }

}