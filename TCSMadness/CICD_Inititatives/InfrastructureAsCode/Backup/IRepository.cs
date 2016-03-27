using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoStore.Domain
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
