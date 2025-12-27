using Desafio_Lynx.Data;
using Desafio_Lynx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Lynx.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            // Busca o pedido
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == payment.Order_Id);

            if (order == null)
                return BadRequest($"Pedido {payment.Order_Id} não encontrado.");

            // Total do pedido
            var orderTotal = order.Items.Sum(i => i.Quantity * i.Unit_Price_Cents);

            // Soma pagamentos já feitos
            var totalPaid = _context.Payments
                .Where(p => p.Order_Id == order.Id)
                .Sum(p => p.Amount_Cents);

            var newTotalPaid = totalPaid + payment.Amount_Cents;

            payment.Paid_At = DateTime.UtcNow;
            _context.Payments.Add(payment);

            // Marca como pago se atingir o total
            if (newTotalPaid >= orderTotal)
                order.Status = "PAID";

            _context.SaveChanges();

            return Created("", new
            {
                OrderId = order.Id,
                TotalOrder = orderTotal,
                TotalPaid = newTotalPaid,
                Status = order.Status
            });
        }
    }
}
