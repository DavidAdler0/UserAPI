using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerMembersController : ControllerBase
    {
        private readonly UserAPIContext _context;

        public LedgerMembersController(UserAPIContext context)
        {
            _context = context;
        }

        // GET: api/LedgerMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgerMember>>> GetLedgerMember()
        {
            return await _context.LedgerMember.ToListAsync();
        }

        // GET: api/LedgerMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgerMember>> GetLedgerMember(int id)
        {
            var ledgerMember = await _context.LedgerMember.FindAsync(id);

            if (ledgerMember == null)
            {
                return NotFound();
            }

            return ledgerMember;
        }

        // PUT: api/LedgerMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgerMember(int id, LedgerMember ledgerMember)
        {
            if (id != ledgerMember.LedgerMemberId)
            {
                return BadRequest();
            }

            _context.Entry(ledgerMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerMemberExists(id))
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

        // POST: api/LedgerMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LedgerMember>> PostLedgerMember(LedgerMember ledgerMember)
        {
            _context.LedgerMember.Add(ledgerMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLedgerMember", new { id = ledgerMember.LedgerMemberId }, ledgerMember);
        }

        // DELETE: api/LedgerMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedgerMember(int id)
        {
            var ledgerMember = await _context.LedgerMember.FindAsync(id);
            if (ledgerMember == null)
            {
                return NotFound();
            }

            _context.LedgerMember.Remove(ledgerMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgerMemberExists(int id)
        {
            return _context.LedgerMember.Any(e => e.LedgerMemberId == id);
        }
    }
}
