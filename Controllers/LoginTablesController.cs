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
    public class LoginTablesController : ControllerBase
    {
        ProjectGladiatorContext pgc = new ProjectGladiatorContext();

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(pgc.LoginTables.ToList());
        }

        [HttpPost]
        public IActionResult Create(LoginTable l)
        {
            pgc.LoginTables.Add(l);
            pgc.SaveChanges();
            return Ok(l);
        }
    }
}
