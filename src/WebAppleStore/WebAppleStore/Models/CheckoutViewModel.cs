using System.ComponentModel.DataAnnotations;

namespace WebAppleStore.Models
{
    public class CheckoutViewModel
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; } = string.Empty;

        public string? Email { get; set; }
        public string? Note { get; set; }

        [Range(1, 100, ErrorMessage = "Số lượng không hợp lệ")]
        public int Quantity { get; set; } = 1;
    }
}
