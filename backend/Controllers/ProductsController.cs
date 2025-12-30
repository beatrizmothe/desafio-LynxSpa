using Desafio_Lynx.Data;
using Desafio_Lynx.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Lynx.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET / products
        [HttpGet]
        public IActionResult GetProducts(
            [FromQuery] string? category,
            [FromQuery] bool? active,
            [FromQuery] string? search)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(p => p.Category == category);

            if (active.HasValue)
                query = query.Where(p => p.Active == active.Value);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search));

            return Ok(query.ToList());
        }

        // POST / products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                return BadRequest();

            if (product.PriceCents < 0)
                return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }

        // PUT / products {id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.PriceCents = updatedProduct.PriceCents;
            product.Active = updatedProduct.Active;

            _context.SaveChanges();

            return Ok(product);
        }

        // DELETE / products {id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
