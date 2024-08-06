using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Shared.DataTransferObjects;

public abstract record ProductForManipulationDto
{
    [Required(ErrorMessage = "Product name is a required field.")]
    [StringLength(350, ErrorMessage = "Maximum length for the product name is 350 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Price is a required field.")]
    [Range(0, double.MaxValue, ErrorMessage = "The price must be a non-negative value.")]
    public double? Price { get; init; }

    public string? Description { get; init; }
    [JsonPropertyName("category_id")]
    [Required(ErrorMessage = "Category ID is a required field.")]
    public Guid CategoryId { get; init; }
}
public record ProductForCreationDto : ProductForManipulationDto
{
    [Required(ErrorMessage = "Thumbnail is a required field.")]
    public required IFormFile Thumbnail { get; init; }
}
public record ProductForUpdateDto : ProductForManipulationDto
{
    public IFormFile? Thumbnail { get; init; } 
}
