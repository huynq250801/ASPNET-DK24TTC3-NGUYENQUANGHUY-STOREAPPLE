using System;

namespace WebAppleStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        // Product info
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string? ImageUrl { get; set; }

        // Relationship
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Extra info
        public string? Description { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }

        // Timestamps (Fix lỗi datetime2 → datetime)
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
