using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class OrderDetail
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }
    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; } 

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total => Price * Quantity; 
}