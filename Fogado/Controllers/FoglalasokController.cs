using Fogado.Data;
using Fogado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fogado.Controllers
{
    public class FoglalasokController : ControllerBase
    {
        private readonly FogadoDbContext _context;

        public FoglalasokController(FogadoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foglalasok>>> GetFoglalasok()
        {
            return await _context.Foglalasok
                .Include(f => f.Vendegek)
                .Include(f => f.Szobak)
            .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Foglalasok>> PostFoglalas(Foglalasok foglalas)
        {
            _context.Foglalas.Add(foglalas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFoglalasok), new { id = Foglalasok.fsorsz }, foglalas);
        }
    }
}
}
