using System.Collections.Generic;

namespace WebAppleStore.Models
{
    public class HomeViewModel
    {
        public List<Product> Iphones { get; set; } = new();
        public List<Product> Ipads { get; set; } = new();
        public List<Product> Watches { get; set; } = new();
        public List<Product> Accessories { get; set; } = new();
    }
}
