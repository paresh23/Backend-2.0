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
    public class AdminControlsController : ControllerBase
    {
        private readonly ProjectGladiatorContext _context;

        public AdminControlsController(ProjectGladiatorContext context)
        {
            _context = context;
        }

        // GET: api/AdminControls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminControl>>> GetAdminControls()
        {
            return await _context.AdminControls.ToListAsync();
        }

        // GET: api/AdminControls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminControl>> GetAdminControl(int id)
        {
            var adminControl = await _context.AdminControls.FindAsync(id);

            if (adminControl == null)
            {
                return NotFound();
            }

            return adminControl;
        }

        // PUT: api/AdminControls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminControl(int id, AdminControl adminControl)
        {
            if (id != adminControl.Aid)
            {
                return BadRequest();
            }

            _context.Entry(adminControl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminControlExists(id))
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

        // POST: api/AdminControls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminControl>> PostAdminControl(AdminControl adminControl)
        {
            _context.AdminControls.Add(adminControl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminControl", new { id = adminControl.Aid }, adminControl);
        }

        // DELETE: api/AdminControls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminControl(int id)
        {
            var adminControl = await _context.AdminControls.FindAsync(id);
            if (adminControl == null)
            {
                return NotFound();
            }

            _context.AdminControls.Remove(adminControl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminControlExists(int id)
        {
            return _context.AdminControls.Any(e => e.Aid == id);
        }
    }
}
