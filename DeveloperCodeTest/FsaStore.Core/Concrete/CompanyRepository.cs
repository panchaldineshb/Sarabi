using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.Core.Concrete
{
    /// <summary>
    /// Refer to following link for the example
    /// http://codereview.stackexchange.com/questions/11785/ef-code-first-with-repository-unitofwork-and-dbcontextfactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompanyRepository : IDisposable, IRepository<Company>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<Company> _dbSet;

        public CompanyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Company>();
        }

        public virtual IQueryable<Company> All()
        {
            return _dbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Company, bool>> predicate)
        {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual int Count(Expression<Func<Company, bool>> predicate = null)
        {
            var set = _dbContext.Set<Company>();
            return (predicate == null) ?
                   set.Count() :
                   set.Count(predicate);
        }

        public virtual Company Create(Company entity)
        {
            var newEntry = _dbSet.Add(entity);
            return newEntry;
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(Company entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<Company, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }
        }

        /// <summary>
        ///   Dispose context.
        /// </summary>
        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }

        public virtual IQueryable<Company> Filter(Expression<Func<Company, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<Company> Filter(Expression<Func<Company, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual Company Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual Company Find(Expression<Func<Company, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<Company> FindIncluding(Expression<Func<Company, object>>[] includeProperties)
        {
            var set = _dbContext.Set<Company>();

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    set.Include(include);
                }
            }
            return set.AsQueryable();
        }

        public virtual Company FindIncluding(Expression<Func<Company, bool>> predicate, Expression<Func<Company, object>>[] includeProperties)
        {
            var set = _dbContext.Set<Company>();

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    set.Include(include);
                }
            }
            return set.FirstOrDefault(predicate);
        }

        public virtual IQueryable<Company> Get(Expression<Func<Company, bool>> filter = null, Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Company> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!String.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }
            else
            {
                return query.AsQueryable();
            }
        }

        public virtual Company GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        ///   Save to database.
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveChanges()
        {
            return _dbContext.SaveChanges() == 1;
        }

        public virtual void Upsert(Company entity)
        {
            var entry = _dbContext.Entry(entity);
            _dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }
    }
}