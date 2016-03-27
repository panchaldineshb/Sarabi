using System.Collections.Generic;

namespace CICD.Infrastructure.Abstraction
{
    public interface IRepository<T> where T : IEntity<int>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T item);

        void Delete(T item);

        void Update(T item);
    }
}