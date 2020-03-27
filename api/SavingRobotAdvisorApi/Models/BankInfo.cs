using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public class BankInfo{
        public Bank BankName {set; get;}
        public SavingAccountType SavingAccountType {set; get;}
        public CreditCardType CreditCardType {set; get;}
    }
}