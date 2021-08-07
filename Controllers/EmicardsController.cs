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
    public class EmicardsController : ControllerBase
    {
        private readonly ProjectGladiatorContext _context;

        public EmicardsController(ProjectGladiatorContext context)
        {
            _context = context;
        }

        // GET: api/Emicards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emicard>>> GetEmicards()
        {
            return await _context.Emicards.ToListAsync();
        }

        // GET: api/Emicards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emicard>> GetEmicard(int id)
        {
            var emicard = await _context.Emicards.FindAsync(id);

            if (emicard == null)
            {
                return NotFound();
            }

            return emicard;
        }

        // PUT: api/Emicards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmicard(int id, Emicard emicard)
        {
            if (id != emicard.Eid)
            {
                return BadRequest();
            }

            _context.Entry(emicard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmicardExists(id))
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

        // POST: api/Emicards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emicard>> PostEmicard(Emicard emicard)
        {
            _context.Emicards.Add(emicard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmicard", new { id = emicard.Eid }, emicard);
        }

        // DELETE: api/Emicards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmicard(int id)
        {
            var emicard = await _context.Emicards.FindAsync(id);
            if (emicard == null)
            {
                return NotFound();
            }

            _context.Emicards.Remove(emicard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmicardExists(int id)
        {
            return _context.Emicards.Any(e => e.Eid == id);
        }
    }
}
