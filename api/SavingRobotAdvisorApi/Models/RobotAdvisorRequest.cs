
namespace SavingRobotAdvisorApi.Models
{
    public class RobotAdvisorRequest
    {
        public decimal Income { get; set; }
        public decimal Balance  { get; set; }
        public MonthlySpending MonthlySpending { get; set; }
    }
}