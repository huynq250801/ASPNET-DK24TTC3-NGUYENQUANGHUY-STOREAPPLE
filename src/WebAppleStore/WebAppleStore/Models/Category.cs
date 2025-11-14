using System;
using System.Collections.Generic;

namespace WebAppleStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        public required string Name { get; set; }       // BẮT BUỘC
        public string? Slug { get; set; }               // CHO PHÉP NULL

        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
