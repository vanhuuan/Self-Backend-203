using SelfBackEnd.Models;
using System.Linq.Expressions;

namespace SelfBackEnd.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseModel
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    T GetById(object id);
    void Insert(T obj);
    void AddRange(IEnumerable<T> items);
    void Update(T obj);
    void Delete(object id);
    void Save();
}
