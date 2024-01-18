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
    public class InsuranceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceProduct>>> GetProduct()
        {
            if(_context.InsuranceProducts == null)
            {
                return NotFound();
            }

            return await _context.InsuranceProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceProduct>> GetProduct(int id)
        {
            if (_context.InsuranceProducts == null)
            {
                return NotFound();
            }

            var insuranceProduct = await _context.InsuranceProducts
                .Include(ip => ip.Categorie)
                .Include(ip => ip.Typee)
                .Include(ip => ip.Package)
                .Include(ip => ip.AuthorizedUser)
                .Include(ip => ip.User) // Include if you want to retrieve related users
                .FirstOrDefaultAsync(ip => ip.InsuranceId == id);

            if(insuranceProduct == null)
            {
                return NotFound();
            }

            var insuranceDto = new InsuranceDTO
            {
                InsuranceName = insuranceProduct.InsuranceName,
                CategoryName = insuranceProduct.Categorie.CategoryName,
                TypeName = insuranceProduct.Typee.TypeName,
                PackageName = insuranceProduct.Package.Name,
                AuthorizedName = insuranceProduct.AuthorizedUser.AuthorizedName,
                Description = insuranceProduct.Description,
            };

            return Ok(insuranceDto);
        }

        [HttpPost]
        public async Task<ActionResult<InsuranceProduct>> PostProduct(InsuranceDTO productDto)
        {
            if(_context.InsuranceProducts == null) {
                return BadRequest();
            }

            var product = new InsuranceProduct
            {
                InsuranceName = productDto.InsuranceName,
                Description = productDto.Description,
                Premium = productDto.Premium,
            };

            if(!string.IsNullOrEmpty(productDto.CategoryName)) {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName == productDto.CategoryName);
                if(category == null)
                {
                    return BadRequest();
                }

                product.CategoryId = category.CategoryId;
            }

            if(!string.IsNullOrEmpty(productDto.TypeName))
            {
                var type = _context.Typees.FirstOrDefault(c => c.TypeName == productDto.TypeName);
                if (type == null)
                {
                    return BadRequest();
                }

                product.TypeId = type.TypeId;
            }

            if (!string.IsNullOrEmpty(productDto.PackageName))
            {
                var package = _context.Packages.FirstOrDefault(c => c.Name == productDto.PackageName);
                if (package == null)
                {
                    return BadRequest();
                }

                product.PackageId = package.PackageId;
            }

            if(!string.IsNullOrEmpty(productDto.AuthorizedName))
            {
                var user = _context.AuthorizedUsers.FirstOrDefault(a => a.AuthorizedName == productDto.AuthorizedName);
                if (user == null)
                {
                    return BadRequest();
                }

                product.AuthorizedId = user.AuthorizedId;
            }

            _context.InsuranceProducts.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(int id, InsuranceDTOId productDto)
        {
            if(id != productDto.InsuranceIdDto)
            {
                return BadRequest();
            }
            var product = new InsuranceProduct
            {
                InsuranceId = productDto.InsuranceIdDto,
                InsuranceName = productDto.InsuranceName,
                Description = productDto.Description,
                Premium = productDto.Premium,
            };
            if (!string.IsNullOrEmpty(productDto.CategoryName))
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName == productDto.CategoryName);
                if (category == null)
                {
                    return BadRequest();
                }

                product.CategoryId = category.CategoryId;
            }

            if (!string.IsNullOrEmpty(productDto.TypeName))
            {
                var type = _context.Typees.FirstOrDefault(c => c.TypeName == productDto.TypeName);
                if (type == null)
                {
                    return BadRequest();
                }

                product.TypeId = type.TypeId;
            }

            if (!string.IsNullOrEmpty(productDto.PackageName))
            {
                var package = _context.Packages.FirstOrDefault(c => c.Name == productDto.PackageName);
                if (package == null)
                {
                    return BadRequest();
                }

                product.PackageId = package.PackageId;
            }

            if (!string.IsNullOrEmpty(productDto.AuthorizedName))
            {
                var user = _context.AuthorizedUsers.FirstOrDefault(a => a.AuthorizedName == productDto.AuthorizedName);
                if (user == null)
                {
                    return BadRequest();
                }

                product.AuthorizedId = user.AuthorizedId;
            }

            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }else
                {
                    throw;
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(_context.InsuranceProducts == null)
            {
                return NotFound();
            }

            var product = _context.InsuranceProducts.FirstOrDefault(p => p.InsuranceId == id);
            if (product == null)
            {
                return BadRequest();
            }

            _context.InsuranceProducts.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return (_context.InsuranceProducts?.Any(e => e.InsuranceId == id)).GetValueOrDefault();
        }
    }
}
