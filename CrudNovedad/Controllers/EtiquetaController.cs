// EtiquetasController.cs
using System;
using System.Linq;
using CrudNovedad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class EtiquetasController : ControllerBase
{
    private readonly NovedadDbContext _context;

    public EtiquetasController(NovedadDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetEtiquetas()
    {
        var etiquetas = _context.Etiqueta.ToList();
        return Ok(etiquetas);
    }

    [HttpGet("{id}")]
    public IActionResult GetEtiqueta(Guid id)
    {
        var etiqueta = _context.Etiqueta.Find(id);

        if (etiqueta == null)
        {
            return NotFound();
        }

        return Ok(etiqueta);
    }

    [HttpPost]
    public IActionResult CreateEtiqueta(Etiqueta etiqueta)
    {
        _context.Etiqueta.Add(etiqueta);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEtiqueta), new { id = etiqueta.Id }, etiqueta);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEtiqueta(Guid id, Etiqueta etiqueta)
    {
        if (id != etiqueta.Id)
        {
            return BadRequest();
        }

        _context.Entry(etiqueta).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Etiqueta.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEtiqueta(Guid id)
    {
        var etiqueta = _context.Etiqueta.Find(id);

        if (etiqueta == null)
        {
            return NotFound();
        }

        _context.Etiqueta.Remove(etiqueta);
        _context.SaveChanges();

        return NoContent();
    }
}
