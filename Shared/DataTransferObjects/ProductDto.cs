namespace Shared.DataTransferObjects;

public record ProductDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public double? Price { get; init; }
    public string? Thumbnail { get; init; }
    public string? Description { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public Guid CategoryId { get; init; }
}