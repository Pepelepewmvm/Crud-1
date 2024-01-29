using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudNovedad.Models;

namespace CrudNovedad.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoNovController : ControllerBase
    {
        private readonly NovedadDbContext _context;

        public TipoNovController(NovedadDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoNov
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoNov>>> GetTipoNovs()
        {
            return await _context.TipoNovSet.ToListAsync();
        }

        // GET: api/TipoNov/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoNov>> GetTipoNov(Guid id)
        {
            var tipoNov = await _context.TipoNovSet.FindAsync(id);

            if (tipoNov == null)
            {
                return NotFound();
            }

            return tipoNov;
        }

        // POST: api/TipoNov
        [HttpPost]
        public async Task<ActionResult<TipoNov>> PostTipoNov(TipoNov tipoNov)
        {
            _context.TipoNovSet.Add(tipoNov);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoNov", new { id = tipoNov.Id }, tipoNov);
        }

        // PUT: api/TipoNov/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoNov(Guid id, TipoNov tipoNov)
        {
            if (id != tipoNov.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoNov).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoNovExists(id))
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

        // DELETE: api/TipoNov/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoNov(Guid id)
        {
            var tipoNov = await _context.TipoNovSet.FindAsync(id);
            if (tipoNov == null)
            {
                return NotFound();
            }

            _context.TipoNovSet.Remove(tipoNov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoNovExists(Guid id)
        {
            return _context.TipoNovSet.Any(e => e.Id == id);
        }
    }
}
    