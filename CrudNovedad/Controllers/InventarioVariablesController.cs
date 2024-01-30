// InventarioVariablesController.cs
using System;
using System.Linq;
using CrudNovedad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class InventarioVariablesController : ControllerBase
{
    private readonly NovedadDbContext _context;

    public InventarioVariablesController(NovedadDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetInventarioVariables()
    {
        var inventarioVariables = _context.InventarioVariables.ToList();
        return Ok(inventarioVariables);
    }

    [HttpGet("{id}")]
    public IActionResult GetInventarioVariable(Guid id)
    {
        var inventarioVariable = _context.InventarioVariables.Find(id);

        if (inventarioVariable == null)
        {
            return NotFound();
        }

        return Ok(inventarioVariable);
    }

    [HttpPost]
    public IActionResult CreateInventarioVariable(InventarioVariable inventarioVariable)
    {
        _context.InventarioVariables.Add(inventarioVariable);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetInventarioVariable), new { id = inventarioVariable.Id }, inventarioVariable);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateInventarioVariable(Guid id, InventarioVariable inventarioVariable)
    {
        if (id != inventarioVariable.Id)
        {
            return BadRequest();
        }

        _context.Entry(inventarioVariable).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.InventarioVariables.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteInventarioVariable(Guid id)
    {
        var inventarioVariable = _context.InventarioVariables.Find(id);

        if (inventarioVariable == null)
        {
            return NotFound();
        }

        _context.InventarioVariables.Remove(inventarioVariable);
        _context.SaveChanges();

        return NoContent();
    }
}
