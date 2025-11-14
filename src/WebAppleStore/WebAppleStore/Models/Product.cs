using System;

namespace WebAppleStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }   // Cho phép NULL (EF sẽ gán sau)

        public string? Description { get; set; }

        public int Stock { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
