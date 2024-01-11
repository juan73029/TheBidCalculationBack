using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBidCalculation.Core.Services.Interfaces;
using TheBidCalculation.Entities.DTOs;
using TheBidCalculation.Entities.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBidCalculation.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        // GET api/values/5
        [HttpGet("{value}/{type}")]
        public ActionResult<BidDTO> Get(double value, VehicleTypeEnum type)
        {
            try
            {
                VehicleValueDTO vehicleValue = new VehicleValueDTO() { Value = value, VehicleType = type };
                return _calculatorService.GetBid(vehicleValue);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

