using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Category
{
    [Column("CategoryId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Category name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the category name is 60 characters.")]
    public string? Name { get; set; }
    
    public ICollection<Product>? Products { get; set; }
}

