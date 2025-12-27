using System;
using System.Collections.Generic;

namespace Desafio_Lynx.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string? Status { get; set; }
        public DateTime Created_At { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}