using LastFinal.Data;
using LastFinal.DTOs;
using LastFinal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if(_context.Users == null)
            {
                return NotFound();
            }
            
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDto)
        {
            if(_context.Users == null)
            {
                return BadRequest();
            }

            var user = new User
            {
                UserName = userDto.UserName,
                UserLastName = userDto.UserLastName
            };

            if(!string.IsNullOrEmpty(userDto.ProductName))
            {
                var product = _context.InsuranceProducts.FirstOrDefault(p => p.InsuranceName == userDto.ProductName);
                if(product == null)
                {
                    return BadRequest();
                }

                user.ProductId = product.InsuranceId;
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(int id, UserDTOId userDto)
        {
            if (id != userDto.UserIdDto)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the properties of the existing user with the values from the DTO
            existingUser.UserName = userDto.UserName;
            existingUser.UserLastName = userDto.UserLastName;

            if (!string.IsNullOrEmpty(userDto.ProductName))
            {
                var product = _context.InsuranceProducts.FirstOrDefault(p => p.InsuranceName == userDto.ProductName);
                if (product == null)
                {
                    return BadRequest();
                }

                existingUser.ProductId = product.InsuranceId;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(p => p.UserId == id);
            if (user == null)
            {
                return BadRequest();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
