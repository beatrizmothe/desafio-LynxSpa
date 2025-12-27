using System;

namespace Desafio_Lynx.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Amount_Cents { get; set; }
        public string Payment_Method { get; set; } = null!;
        public DateTime? Paid_At { get; set; }

        public Order? Order { get; set; }
    }
}
