using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record OrderDetailForManipulationDto
{
    [Required(ErrorMessage = "Price is a required field.")]
    [Range(0, int.MaxValue, ErrorMessage = "The price must be a non-negative value.")]
    public int? Quantity { get; init; }
    
    [Required(ErrorMessage = "Price is a required field.")]
    [Range(0, double.MaxValue, ErrorMessage = "The quantity must be a non-negative value.")]
    public double? Price { get; init; }
    
    [Required(ErrorMessage = "Product Id is a required field.")]
    public Guid ProductId { get; init; }
}

public record OrderDetailForCreationDto : OrderDetailForManipulationDto;