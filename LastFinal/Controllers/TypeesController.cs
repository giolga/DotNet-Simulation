using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LastFinal.Data;
using LastFinal.Model;
using LastFinal.DTOs;

namespace LastFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Typees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Typee>>> GetTypees()
        {
          if (_context.Typees == null)
          {
              return NotFound();
          }
            return await _context.Typees.ToListAsync();
        }

        // GET: api/Typees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Typee>> GetTypee(int id)
        {
          if (_context.Typees == null)
          {
              return NotFound();
          }
            var typee = await _context.Typees.FindAsync(id);

            if (typee == null)
            {
                return NotFound();
            }

            return typee;
        }

        // PUT: api/Typees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypee(int id, TypeeDTOId typeeDto)
        {
            if (id != typeeDto.TypeIdDto)
            {
                return BadRequest();
            }

            var typee = _context.Typees.Find(id);
            typee.TypeName = typeeDto.TypeName;

            _context.Entry(typee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Typees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Typee>> PostTypee(TypeeDTO typeeDto)
        {
          if (_context.Typees == null)
          {
              return Problem("Entity set 'AppDbContext.Typees'  is null.");
          }

            var typee = new Typee
            {
                TypeName = typeeDto.TypeName,
            };
            _context.Typees.Add(typee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypee", new { id = typee.TypeId }, typee);
        }

        // DELETE: api/Typees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypee(int id)
        {
            if (_context.Typees == null)
            {
                return NotFound();
            }
            var typee = await _context.Typees.FindAsync(id);
            if (typee == null)
            {
                return NotFound();
            }

            _context.Typees.Remove(typee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeeExists(int id)
        {
            return (_context.Typees?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
