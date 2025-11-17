using System;
using System.Collections.Generic;

namespace WebAppleStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public required string OrderCode { get; set; }
        public required string CustomerName { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public required string Address { get; set; }
        public string? Note { get; set; }

        public DateTime OrderDate { get; set; }

        public required string Status { get; set; }
        public decimal TotalAmount { get; set; }

        // LƯU Ý: không có dấu ? và KHỞI TẠO LIST
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
