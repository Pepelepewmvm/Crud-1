// NovedadesController.cs
using CrudNovedad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NovedadesController : ControllerBase
{
    private readonly NovedadDbContext _context;

    public NovedadesController(NovedadDbContext context)
    {
        _context = context;
    }

    // GET: api/Novedades
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Novedad>>> GetNovedades()
    {
        return await _context.Novedad.ToListAsync();
    }

    // GET: api/Novedades/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Novedad>> GetNovedad(Guid id)
    {
        var novedad = await _context.Novedad.FindAsync(id);

        if (novedad == null)
        {
            return NotFound();
        }

        return novedad;
    }

    // POST: api/Novedades
    [HttpPost]
    public async Task<ActionResult<Novedad>> PostNovedad(Novedad novedad)
    {
        _context.Novedad.Add(novedad);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNovedad", new { id = novedad.Id }, novedad);
    }

    // PUT: api/Novedades/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNovedad(Guid id, Novedad novedad)
    {
        if (id != novedad.Id)
        {
            return BadRequest();
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

    // DELETE: api/Novedades/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNovedad(Guid id)
    {
        var novedad = await _context.Novedad.FindAsync(id);

        if (novedad == null)
        {
            return NotFound();
        }

        _context.Novedad.Remove(novedad);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NovedadExists(Guid id)
    {
        return _context.Novedad.Any(e => e.Id == id);
    }
}
