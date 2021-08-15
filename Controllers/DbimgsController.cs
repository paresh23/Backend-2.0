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
    public class DbimgsController : ControllerBase
    {
        private readonly ProjectGladiatorContext _context;

        public DbimgsController(ProjectGladiatorContext context)
        {
            _context = context;
        }

        // GET: api/Dbimgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dbimg>>> GetDbimgs()
        {
            return await _context.Dbimgs.ToListAsync();
        }

        // GET: api/Dbimgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dbimg>> GetDbimg(int id)
        {
            var dbimg = await _context.Dbimgs.FindAsync(id);

            if (dbimg == null)
            {
                return NotFound();
            }

            return dbimg;
        }

        // PUT: api/Dbimgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbimg(int id, Dbimg dbimg)
        {
            if (id != dbimg.Iid)
            {
                return BadRequest();
            }

            _context.Entry(dbimg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbimgExists(id))
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

        // POST: api/Dbimgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dbimg>> PostDbimg(Dbimg dbimg)
        {
            _context.Dbimgs.Add(dbimg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbimg", new { id = dbimg.Iid }, dbimg);
        }

        // DELETE: api/Dbimgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbimg(int id)
        {
            var dbimg = await _context.Dbimgs.FindAsync(id);
            if (dbimg == null)
            {
                return NotFound();
            }

            _context.Dbimgs.Remove(dbimg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DbimgExists(int id)
        {
            return _context.Dbimgs.Any(e => e.Iid == id);
        }
    }
}
