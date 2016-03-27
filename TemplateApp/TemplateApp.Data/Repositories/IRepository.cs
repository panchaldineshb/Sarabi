using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TemplateApp.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        bool Delete(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Get(int id);

        IQueryable<T> GetAll();

        bool Save(T entity);
    }
}