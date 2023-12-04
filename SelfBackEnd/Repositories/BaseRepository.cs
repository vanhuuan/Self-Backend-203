using Microsoft.EntityFrameworkCore;
using SelfBackEnd.Context;
using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SelfBackEnd.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    private readonly DbContext _context;

    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DashBoardContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();  
    }
    public void Delete(object id)
    {
        var exist = GetById(id);
        if (exist != null)
        {
            _dbSet.Remove(exist);
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(T obj)
    {
        obj.CreatedAt = DateTime.Now;
        _dbSet.Add(obj);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(T obj)
    {
        obj.UpdatedAt = DateTime.Now;
        _dbSet.Update(obj);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public void AddRange(IEnumerable<T> items)
    {
        _dbSet.AddRange(items);
    }
}
