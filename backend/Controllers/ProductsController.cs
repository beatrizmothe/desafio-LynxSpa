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

        // Lista produtos com filtros 
        [HttpGet]
        public IActionResult GetProducts(
            [FromQuery] string? category,
            [FromQuery] bool? active,
            [FromQuery] string? search)
        {
            var query = _context.Products.AsQueryable();

            // Filtro por categoria
            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            // Filtro por ativo/inativo
            if (active.HasValue)
                query = query.Where(p => p.Active == active.Value);

            // Busca por nome
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name!.Contains(search));

            return Ok(query.ToList());
        }

        // Cria um novo produto
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            // Validações 
            if (string.IsNullOrWhiteSpace(product.Name))
                return BadRequest("Nome do produto é obrigatório.");

            if (product.PriceCents < 0)
                return BadRequest("Preço inválido.");

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }

        // Atualiza um produto 
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Produto {id} não encontrado.");

            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.PriceCents = updatedProduct.PriceCents;
            product.Active = updatedProduct.Active;

            _context.SaveChanges();
            return Ok(product);
        }

        // Remove um produto
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Produto {id} não encontrado.");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
