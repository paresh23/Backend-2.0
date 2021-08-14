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

        // PUT: api/LoginTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginTable(string id, LoginTable loginTable)
        {
            if (id != loginTable.UserName)
            {
                return BadRequest();
            }

            pgc.Entry(loginTable).State = EntityState.Modified;


            try
            {
                await pgc.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginTableExists(id))
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
        private bool LoginTableExists(string id)
        {
            return pgc.LoginTables.Any(e => e.UserName == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginTable(string id)
        {
            var loginTable = await pgc.LoginTables.FindAsync(id);
            if (loginTable == null)
            {
                return NotFound();
            }

            pgc.LoginTables.Remove(loginTable);
            await pgc.SaveChangesAsync();

            return NoContent();
        }
    }
}
