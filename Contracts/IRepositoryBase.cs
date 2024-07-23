using System.Linq.Expressions;

namespace Contracts;

// IRepositoryBase: reusablity work with the generic type T, not depend on specify class
public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}