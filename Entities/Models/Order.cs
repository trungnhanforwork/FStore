using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string? FullName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public float? TotalMoney { get; set; }

    public string ShippingMethod { get; set; }
    
    public string ShippingAddress { get; set; }

    public DateTime? ShippingDate { get; set; }

    public string TrackingNumber { get; set; }

    public string PaymentMethod { get; set; }

    
    [ForeignKey("UserId")]
    public string? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}
