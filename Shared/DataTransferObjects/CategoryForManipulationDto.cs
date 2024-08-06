using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record CategoryForManipulationDto
{
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MinLength(2, ErrorMessage = "Minimum length for the Name is 2 characters.")]
    [MaxLength(10, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }
};

public record CategoryForCreationDto : CategoryForManipulationDto;
public record CategoryForUpdateDto : CategoryForManipulationDto;
