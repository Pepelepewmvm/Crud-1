using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudNovedad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNovedad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovedadController : ControllerBase
    {
        private readonly NovedadDbContext _context;

        public NovedadController(NovedadDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Novedad>>> GetNovedades()
        {
            return await _context.NovedadSet.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Novedad>> GetNovedad(Guid id)
        {
            var novedad = await _context.NovedadSet.FindAsync(id);

            if (novedad == null)
            {
                return NotFound();
            }

            return novedad;
        }

        [HttpPost]
        public async Task<ActionResult<Novedad>> PostNovedad(Novedad novedad)
        {
            // Verifica si el TipoNovId proporcionado existe
            if (novedad.TipoNovId.HasValue && !_context.TipoNovSet.Any(t => t.Id == novedad.TipoNovId))
            {
                return BadRequest("El TipoNov especificado no existe.");
            }

            _context.NovedadSet.Add(novedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNovedad), new { id = novedad.Id }, novedad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNovedad(Guid id, Novedad novedad)
        {
            if (id != novedad.Id)
            {
                return BadRequest();
            }

            // Verifica si el TipoNovId proporcionado existe
            if (novedad.TipoNovId.HasValue && !_context.TipoNovSet.Any(t => t.Id == novedad.TipoNovId))
            {
                return BadRequest("El TipoNov especificado no existe.");
            }

            _context.Entry(novedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NovedadExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNovedad(Guid id)
        {
            var novedad = await _context.NovedadSet.FindAsync(id);
            if (novedad == null)
            {
                return NotFound();
            }

            _context.NovedadSet.Remove(novedad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NovedadExists(Guid id)
        {
            return _context.NovedadSet.Any(e => e.Id == id);
        }
    }
}
