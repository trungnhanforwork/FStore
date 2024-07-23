using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Product
{
    [Column("ProductId")]
    public Guid Id { get; set; }

    [Required]
    [StringLength(350)]
    public string? Name { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "")]
    public double? Price { get; set; }

    public string Thumbnail { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}