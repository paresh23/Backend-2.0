using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngToASP.FinanceModel;
using ngToASP.Controllers;
using ngToASP.Model;
using ngToASP.Services;

namespace ngToASP.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ConsumersController : ControllerBase
    {
        private readonly IMailService _mailService;
        ProjectGladiatorContext pgc = new ProjectGladiatorContext();

        public ConsumersController(IMailService mailService)
        {
            _mailService = mailService;
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Consumer consumer)
        {
            MailRequest request=new MailRequest();
            request.Body = "Card Activated";
            request.ToEmail = consumer.EmailId;
            request.Subject = "Activation";
            if (id != consumer.Cid)
            {
                return BadRequest();
            }

            pgc.Entry(consumer).State = EntityState.Modified;

            try
            {
                await _mailService.SendEmailAsync(request);
                await pgc.SaveChangesAsync();
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

        // DELETE: api/Consumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumer(int id)
        {
            var consumer = await pgc.Consumers.FindAsync(id);
            if (consumer == null)
            {
                return NotFound();
            }

            pgc.Consumers.Remove(consumer);
            await pgc.SaveChangesAsync();

            return NoContent();
        }
    }
}
