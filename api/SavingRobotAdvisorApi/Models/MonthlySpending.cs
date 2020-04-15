
namespace SavingRobotAdvisorApi.Models
{
    public class MonthlySpending
    {
        public decimal TotalAmount  { get; set; }
        public decimal GroceryPercent { get; set; }
        public decimal DiningPercent { get; set; }
        public decimal PublicTransportPercent { get; set; }
        public decimal PetrolPercent {get; set;}
        public decimal TelcoPercent { get; set; }
        public decimal TravelPercent { get; set; }
    }

}