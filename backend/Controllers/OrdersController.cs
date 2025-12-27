using Desafio_Lynx.Data;
using Desafio_Lynx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Lynx.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // Lista pedidos com total calculado
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Items)
                .Select(o => new
                {
                    o.Id,
                    o.Status,
                    o.Created_At,
                    // total = quantidade * preço de cada item
                    Total = o.Items.Sum(i => i.Quantity * i.Unit_Price_Cents)
                })
                .ToList();

            return Ok(orders);
        }

        // Retorna um pedido específico
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound($"Pedido {id} não encontrado.");

            var total = order.Items.Sum(i => i.Quantity * i.Unit_Price_Cents);

            return Ok(new
            {
                order.Id,
                order.Status,
                order.Created_At,
                Items = order.Items,
                Total = total
            });
        }

        // Cria um novo pedido
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            // Se não tiver itens, retorna erro
            if (order.Items == null || !order.Items.Any())
                return BadRequest("O pedido precisa ter pelo menos um item.");

            order.Status = "NEW";
            order.Created_At = DateTime.UtcNow;

            // salva o pedido primeiro para gerar o Id
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in order.Items)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.Product_Id);

                if (product == null)
                    return BadRequest($"Produto {item.Product_Id} não encontrado.");

                if (!product.Active)
                    return BadRequest($"Produto {product.Name} inativo.");

                item.Order_Id = order.Id;
                item.Unit_Price_Cents = product.PriceCents;
            }

            _context.OrderItems.AddRange(order.Items);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, new
            {
                order.Id,
                order.Status,
                order.Created_At
            });
        }
    }
}
