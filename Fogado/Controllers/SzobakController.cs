using Fogado.Data;
using Fogado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fogado.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SzobakController : ControllerBase
        {
            private readonly FogadoDbContext _context;

            public SzobakController(FogadoDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Szobak>>> GetSzobak()
            {
                return await _context.Szoba.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Szobak>> GetSzoba(int id)
            {
                var szoba = await _context.Szoba.FindAsync(id);
                if (szoba == null) return NotFound();
                return szoba;
            }

            [HttpPost]
            public async Task<ActionResult<Szobak>> PostSzoba(Szobak szoba)
            {
                _context.Szoba.Add(szoba);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSzoba), new { id = szoba.Szazon }, szoba);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutSzoba(int id, Szobak szoba)
            {
                if (id != szoba.Szazon) return BadRequest();
                _context.Entry(szoba).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSzoba(int id)
            {
                var szoba = await _context.Szoba.FindAsync(id);
                if (szoba == null) return NotFound();
                _context.Szoba.Remove(szoba);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
}
