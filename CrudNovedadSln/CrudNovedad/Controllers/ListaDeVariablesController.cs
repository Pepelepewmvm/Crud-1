// En el archivo ListaDeVariablesController.cs
using CrudNovedad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeVariablesController : ControllerBase
    {
        private readonly NovedadDbContext _context;

        public ListaDeVariablesController(NovedadDbContext context)
        {
            _context = context;
        }

        // GET: api/ListaDeVariables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaDeVariables>>> GetListaDeVariables()
        {
            return await _context.ListaDeVariablesSet.ToListAsync();
        }

        // GET: api/ListaDeVariables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaDeVariables>> GetListaDeVariables(int id)
        {
            var listaDeVariables = await _context.ListaDeVariablesSet.FindAsync(id);

            if (listaDeVariables == null)
            {
                return NotFound();
            }

            return listaDeVariables;
        }

        // POST: api/ListaDeVariables
        [HttpPost]
        public async Task<ActionResult<ListaDeVariables>> PostListaDeVariables(ListaDeVariables listaDeVariables)
        {
            _context.ListaDeVariablesSet.Add(listaDeVariables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaDeVariables", new { id = listaDeVariables.Id }, listaDeVariables);
        }

        // PUT: api/ListaDeVariables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaDeVariables(int id, ListaDeVariables listaDeVariables)
        {
            if (id != listaDeVariables.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaDeVariables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaDeVariablesExists(id))
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

        // DELETE: api/ListaDeVariables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaDeVariables(int id)
        {
            var listaDeVariables = await _context.ListaDeVariablesSet.FindAsync(id);
            if (listaDeVariables == null)
            {
                return NotFound();
            }

            _context.ListaDeVariablesSet.Remove(listaDeVariables);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaDeVariablesExists(int id)
        {
            return _context.ListaDeVariablesSet.Any(e => e.Id == id);
        }
    }
}
