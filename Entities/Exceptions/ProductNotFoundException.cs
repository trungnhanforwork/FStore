namespace Entities.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base($"The product with id: {id} doesn't exist in the database.")
    {
    }
}