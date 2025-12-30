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

        // POST / payments
        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == request.Order_Id);

            if (order == null || order.Status == "PAID")
                return BadRequest();

            if (request.Amount_Cents <= 0)
                return BadRequest();

            var orderTotal = order.Items.Sum(i => i.Quantity * i.Unit_Price_Cents);

            var totalPaid = _context.Payments
                .Where(p => p.Order_Id == order.Id)
                .Sum(p => p.Amount_Cents);

            var newTotalPaid = totalPaid + request.Amount_Cents;

             var payment = new Payment
            {
                Order_Id = request.Order_Id,
                Amount_Cents = request.Amount_Cents,
                Payment_Method = request.Payment_Method,
                Paid_At = DateTime.UtcNow
            };
            
            _context.Payments.Add(payment);

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
