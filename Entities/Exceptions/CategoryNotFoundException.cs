namespace Entities.Exceptions;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(Guid id) : base($"The category with id: {id} doesn't exist in the database.")
    {
    }
}