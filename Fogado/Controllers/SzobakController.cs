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
            private readonly FogadoContext _context;

            public SzobakController(FogadoContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Szoba>>> GetSzobak()
            {
                return await _context.Szobak.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Szoba>> GetSzoba(int id)
            {
                var szoba = await _context.Szobak.FindAsync(id);
                if (szoba == null) return NotFound();
                return szoba;
            }

            [HttpPost]
            public async Task<ActionResult<Szoba>> PostSzoba(Szoba szoba)
            {
                _context.Szobak.Add(szoba);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSzoba), new { id = szoba.Szazon }, szoba);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutSzoba(int id, Szoba szoba)
            {
                if (id != szoba.Szazon) return BadRequest();
                _context.Entry(szoba).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSzoba(int id)
            {
                var szoba = await _context.Szobak.FindAsync(id);
                if (szoba == null) return NotFound();
                _context.Szobak.Remove(szoba);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
}
