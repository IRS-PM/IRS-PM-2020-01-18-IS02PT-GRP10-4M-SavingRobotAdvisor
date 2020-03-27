using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingRobotAdvisorApi.Models;
using SavingRobotAdvisorApi.Service;

namespace SavingRobotAdvisorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingRobotAdvisorController : ControllerBase
    {
        // Sample : 
        // https://localhost:5001/api/SavingRobotAdvisor/?income=5000&balance=30000&spending=500
        [HttpGet]
        public ActionResult<OptimalResult> Get(decimal income, decimal balance, decimal spending)
        {
            var service = new SavingRobotAdvisorService();
            OptimalResult result = service.GetOptimalResult(income,balance,spending);

            return result;
        }
    }
}
