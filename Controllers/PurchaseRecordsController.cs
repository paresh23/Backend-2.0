﻿using System;
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
    public class PurchaseRecordsController : ControllerBase
    {
        private readonly ProjectGladiatorContext _context;

        public PurchaseRecordsController(ProjectGladiatorContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseRecord>>> GetPurchaseRecords()
        {
            return await _context.PurchaseRecords.ToListAsync();
        }

        // GET: api/PurchaseRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseRecord>> GetPurchaseRecord(int id)
        {
            var purchaseRecord = await _context.PurchaseRecords.FindAsync(id);

            if (purchaseRecord == null)
            {
                return NotFound();
            }

            return purchaseRecord;
        }

        // PUT: api/PurchaseRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseRecord(int id, PurchaseRecord purchaseRecord)
        {
            if (id != purchaseRecord.Prid)
            {
                return BadRequest();
            }

            _context.Entry(purchaseRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseRecordExists(id))
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

        // POST: api/PurchaseRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseRecord>> PostPurchaseRecord(PurchaseRecord purchaseRecord)
        {
            _context.PurchaseRecords.Add(purchaseRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseRecord", new { id = purchaseRecord.Prid }, purchaseRecord);
        }

        // DELETE: api/PurchaseRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseRecord(int id)
        {
            var purchaseRecord = await _context.PurchaseRecords.FindAsync(id);
            if (purchaseRecord == null)
            {
                return NotFound();
            }

            _context.PurchaseRecords.Remove(purchaseRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseRecordExists(int id)
        {
            return _context.PurchaseRecords.Any(e => e.Prid == id);
        }
    }
}
