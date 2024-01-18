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
    public class AuthorizedUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorizedUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AuthorizedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorizedUser>>> GetAuthorizedUsers()
        {
          if (_context.AuthorizedUsers == null)
          {
              return NotFound();
          }
            return await _context.AuthorizedUsers.ToListAsync();
        }

        // GET: api/AuthorizedUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizedUser>> GetAuthorizedUser(int id)
        {
          if (_context.AuthorizedUsers == null)
          {
              return NotFound();
          }
            var authorizedUser = await _context.AuthorizedUsers.FindAsync(id);

            if (authorizedUser == null)
            {
                return NotFound();
            }

            return authorizedUser;
        }

        // PUT: api/AuthorizedUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorizedUser(int id, AuthorizedUser authorizedUser)
        {
            if (id != authorizedUser.AuthorizedId)
            {
                return BadRequest();
            }

            _context.Entry(authorizedUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizedUserExists(id))
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

        // POST: api/AuthorizedUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorizedUser>> PostAuthorizedUser(AuthorizedDTO authorizedDto)
        {
          if (_context.AuthorizedUsers == null)
          {
              return Problem("Entity set 'AppDbContext.AuthorizedUsers'  is null.");
          }
            var user = new AuthorizedUser
            {
                AuthorizedName = authorizedDto.AuthorizedName

            };
            _context.AuthorizedUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorizedUser", new { id = user.AuthorizedId }, authorizedDto);
        }

        // DELETE: api/AuthorizedUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorizedUser(int id)
        {
            if (_context.AuthorizedUsers == null)
            {
                return NotFound();
            }
            var authorizedUser = await _context.AuthorizedUsers.FindAsync(id);
            if (authorizedUser == null)
            {
                return NotFound();
            }

            _context.AuthorizedUsers.Remove(authorizedUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorizedUserExists(int id)
        {
            return (_context.AuthorizedUsers?.Any(e => e.AuthorizedId == id)).GetValueOrDefault();
        }
    }
}
