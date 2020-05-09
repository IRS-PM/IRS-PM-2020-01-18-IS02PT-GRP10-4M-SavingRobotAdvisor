using SavingRobotAdvisorApi.Common;

namespace SavingRobotAdvisorApi.Models
{
    public abstract class Account<T>
    {
        public long Id { get; set; }
        public Bank BankName {get; set;}

        protected ICalculator<T> Calculator {get; set;}

        public Account (ICalculator<T> calculator)
        {
            Calculator = calculator;
        }

        public abstract T Calculate();
    }
}