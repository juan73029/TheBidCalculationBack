using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBidCalculation.Entities.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBidCalculation.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleTypeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<List<VehicleTypeEnum>> Get()
        {
            var x = Enum.GetValues(typeof(VehicleTypeEnum)).Cast<VehicleTypeEnum>();
            return x.ToList();
        }


    }
}

