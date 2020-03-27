namespace SavingRobotAdvisorApi.Models
{
    public class CalculationResult
    {
        public BankInfo BankInfo {get; set;}
        public InterestResult InterestResult {get; set;}
        public RebateResult RebateResult {get; set;}
        public decimal TotalSavingAmount {get; set;}

        public CalculationResult CombineCalculationResult(BankInfo bankInfo, InterestResult interestResult, RebateResult rebateResult, decimal totalSavingAmount)
        {
            BankInfo = bankInfo;
            InterestResult = interestResult;
            RebateResult = rebateResult;
            TotalSavingAmount = totalSavingAmount;

            return this;
        }
    }
}