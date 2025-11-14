namespace WebAppleStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }      // Cho phép NULL (EF sẽ gán giá trị sau)

        public int ProductId { get; set; }
        public Product? Product { get; set; }  // Cho phép NULL (EF sẽ gán giá trị sau)

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal DiscountPercent { get; set; }
        public decimal Subtotal { get; set; }
    }
}
