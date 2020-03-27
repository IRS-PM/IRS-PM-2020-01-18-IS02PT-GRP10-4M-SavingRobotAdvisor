namespace SavingRobotAdvisorApi.Models
{
    public class OptimalResult
    {
        public string bank {get; set;}
        public string account { get; set; }
        public string card { get; set; }    

        public decimal interest {get; set;}

        public decimal interest_rate {get; set;}

        public decimal rebate {get; set;}

        public decimal rebate_rate {get; set;}
    }
}