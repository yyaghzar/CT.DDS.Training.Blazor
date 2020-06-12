using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController : Controller
    {
        private readonly IBenefitRepository _benefitRepository;

        public BenefitController(IBenefitRepository benefitRepository)
        {
            _benefitRepository = benefitRepository;
        }

        // GET: api/<controller>
        [HttpGet("{employeeID}")]
        public IActionResult GetForEmployee(int employeeID)
        {
            return Ok(_benefitRepository.GetForEmployee(employeeID));
        }

        // GET api/<controller>/5
        [HttpPost("{employeeID}")]
        public void UpdateForEmployee(int employeeID , List<BenefitModel> benefits)
        {
            _benefitRepository.UpdateForEmployee(employeeID,benefits);
        }
    }
}
