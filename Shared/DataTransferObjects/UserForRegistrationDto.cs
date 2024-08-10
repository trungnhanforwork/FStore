using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record UserForRegistrationDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Email { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? PhoneNumber { get; init; }
    public ICollection<string>? Roles { get; init; }
}