using Desafio_Lynx.Data;
using Desafio_Lynx.Models;
using Desafio_Lynx.Dtos;
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

        // GET / orders
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
                    Total = o.Items.Sum(i => i.Quantity * i.Unit_Price_Cents)
                })
                .ToList();

            return Ok(orders);
        }

        // GET / orders {id}
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            return Ok(new
            {
                order.Id,
                order.Status,
                order.Created_At,
                Items = order.Items.Select(i => new
                {
                    i.ProductId,
                    i.Quantity,
                    i.Unit_Price_Cents
                }),
                Total = order.Items.Sum(i => i.Quantity * i.Unit_Price_Cents)
            });
        }

        // POST / orders
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
                return BadRequest();

            var order = new Order
            {
                Status = "NEW",
                Created_At = DateTime.UtcNow
            };

            foreach (var item in request.Items)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product == null || !product.Active)
                    return BadRequest();

                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Unit_Price_Cents = product.PriceCents
                });
            }

            _context.Orders.Add(order);
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
