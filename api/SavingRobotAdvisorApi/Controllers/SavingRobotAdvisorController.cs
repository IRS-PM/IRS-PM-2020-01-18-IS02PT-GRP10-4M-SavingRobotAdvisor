using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingRobotAdvisorApi.Models;
using SavingRobotAdvisorApi.Service;
using Newtonsoft.Json;

namespace SavingRobotAdvisorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingRobotAdvisorController : ControllerBase
    {
       // Request URL : http://localhost:5000/api/SavingRobotAdvisor
       // Request Content-Type: application/json
       // Request Body: "{\"Income\":5000,\"Balance\":10000,\"MonthlySpending\":{\"TotalAmount\":2000,\"GroceryPercent\":0.35,\"DiningPercent\":0.25,\"PublicTransportPercent\":0.05,\"PetrolPercent\":0.2,\"TelcoPercent\":0.05,\"TravelPercent\":0.1}}"

       [HttpPut]
       public ActionResult<List<OptimalResult>> Get([FromBody] string jsonRequestMessage)
        {
            var request = JsonConvert.DeserializeObject<RobotAdvisorRequest>(jsonRequestMessage);
            
            var service = new SavingRobotAdvisorService();
            List<OptimalResult> result = service.GetOptimalResult(request);

            return result;
        }
    }
}
