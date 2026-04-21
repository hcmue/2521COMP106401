using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWebAPI.Data;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoasController : ControllerBase
    {
        private readonly MyeStoreContext _context;

        public HangHoasController(MyeStoreContext context)
        {
            _context = context;
        }

        // GET: api/HangHoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangHoa>>> GetHangHoas()
        {
            return await _context.HangHoas.ToListAsync();
        }

        // GET: api/HangHoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HangHoa>> GetHangHoa(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);

            if (hangHoa == null)
            {
                return NotFound();
            }

            return hangHoa;
        }

        // PUT: api/HangHoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHangHoa(int id, HangHoa hangHoa)
        {
            if (id != hangHoa.MaHh)
            {
                return BadRequest();
            }

            _context.Entry(hangHoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangHoaExists(id))
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

        // POST: api/HangHoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HangHoa>> PostHangHoa(HangHoa hangHoa)
        {
            _context.HangHoas.Add(hangHoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHangHoa", new { id = hangHoa.MaHh }, hangHoa);
        }

        // DELETE: api/HangHoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHangHoa(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            _context.HangHoas.Remove(hangHoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.MaHh == id);
        }
    }
}
