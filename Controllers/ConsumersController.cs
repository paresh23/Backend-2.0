using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngToASP.FinanceModel;

namespace ngToASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumersController : ControllerBase
    {
        ProjectGladiatorContext pgc = new ProjectGladiatorContext();

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(pgc.Consumers.ToList());
        }

        [HttpPost]
        public IActionResult Create(Consumer l)
        {
            pgc.Consumers.Add(l);
            pgc.SaveChanges();
            return Ok(l);
        }
    }
}
