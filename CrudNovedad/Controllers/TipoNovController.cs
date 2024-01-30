using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudNovedad.Models;

[ApiController]
[Route("api/[controller]")]
public class TipoNovController : ControllerBase
{
    private readonly NovedadDbContext _context;

    public TipoNovController(NovedadDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetTipoNovs()
    {
        var tipoNovs = _context.TipoNov.ToList();
        return Ok(tipoNovs);
    }

    [HttpGet("{id}")]
    public IActionResult GetTipoNov(Guid id)
    {
        var tipoNov = _context.TipoNov.Find(id);

        if (tipoNov == null)
        {
            return NotFound();
        }

        return Ok(tipoNov);
    }

    [HttpPost]
    public IActionResult CreateTipoNov(TipoNov tipoNov)
    {
        _context.TipoNov.Add(tipoNov);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTipoNov), new { id = tipoNov.Id }, tipoNov);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTipoNov(Guid id, TipoNov tipoNov)
    {
        if (id != tipoNov.Id)
        {
            return BadRequest();
        }

        _context.Entry(tipoNov).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TipoNov.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTipoNov(Guid id)
    {
        var tipoNov = _context.TipoNov.Find(id);

        if (tipoNov == null)
        {
            return NotFound();
        }

        _context.TipoNov.Remove(tipoNov);
        _context.SaveChanges();

        return NoContent();
    }
}
