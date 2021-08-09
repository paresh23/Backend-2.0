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
    [Produces("application/json")]
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
            LoginTable lt = new LoginTable();
            lt.UserName = l.UserName;
            lt.UPassword = l.CPassword;
            pgc.LoginTables.Add(lt);
            pgc.SaveChanges();
            return Ok(l);
        }
        //[HttpPut]
        //public IActionResult Edit(Consumer l)
        //{
        //    pgc.Consumers.Update(l);
        //    pgc.SaveChanges();
        //    return Ok(l);
        //}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Consumer consumer)
        {
            if (id != consumer.Cid)
            {
                return BadRequest();
            }

            pgc.Entry(consumer).State = EntityState.Modified;

            try
            {
                pgc.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool ConsumerExists(int id)
        {
            return pgc.Consumers.Any(e => e.Cid == id);
        }
    }
}
