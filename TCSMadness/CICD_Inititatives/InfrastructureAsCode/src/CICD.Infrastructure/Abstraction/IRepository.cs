using System.Collections.Generic;
using System.Linq.Expressions;
using System;
namespace CICD.Infrastructure.Abstraction
{
    public interface IRepository<T> where T : IEntity<int>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        void Add(T item);

        void Delete(T item);

        void Update(T item);
    }
}