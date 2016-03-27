using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FsaStore.Core.Abstracts;

namespace FsaStore.Core.Concrete
{
    /// <summary>
    /// Refer to following link for the example
    /// http://codereview.stackexchange.com/questions/11785/ef-code-first-with-repository-unitofwork-and-dbcontextfactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IDisposable, IRepository<T> where T : EntityBase
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public static Object GetPropValue(Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                var info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static bool IsValidType(Type type)
        {
            var collectionTypes = new[] { typeof(EntityBase), typeof(IEnumerable<EntityBase>), typeof(ICollection<EntityBase>), typeof(IList<EntityBase>), typeof(List<EntityBase>) };
            var status = collectionTypes.Any(x => x.IsAssignableFrom(type));
            return status;
        }

        public virtual IQueryable<T> All()
        {
            return _dbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual int Count(Expression<Func<T, bool>> predicate = null)
        {
            var set = _dbContext.Set<T>();
            return (predicate == null) ?
                   set.Count() :
                   set.Count(predicate);
        }

        public virtual T Create(T entity)
        {
            var newEntry = _dbSet.Add(entity);
            return newEntry;
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
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

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> FindIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var set = _dbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    set.Include(include);
                }
            }
            return set.AsQueryable();
        }

        /// <summary>
        /// Refer -> http://blogs.msdn.com/b/adonet/archive/2011/01/31/using-dbcontext-in-ef-feature-ctp5-part-6-loading-related-entities.aspx
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual T FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var set = _dbContext.Set<T>().FirstOrDefault(predicate);

            if (includeProperties != null)
            {
                foreach (var include in includeProperties)
                {
                    // Load the related to a given set
                    _dbContext.Entry(set).Reference(include).Load();
                    //set.Include(include);
                }
            }
            return set;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

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

        public virtual T GetById(object id)
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

        public virtual void Upsert(T entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.Entity.Id > 0)
            {
                entry.CurrentValues.SetValues(entity);
            }
            else
            {
                _dbSet.Add(entity);
            }

            Type type = typeof(T);

            Type baseType = type.BaseType;

            //var baseProperties = type.GetProperties().Where(input => baseType.GetProperties().Any(i => i.Name == input.Name)).ToList();

            //var baseProperties = typeof(T).GetProperties().Where(p => p.PropertyType.BaseType == typeof(EntityBase) || IsValidType(p.PropertyType.BaseType));

            //var baseProperties = typeof(T).GetProperties().Where(p => p.PropertyType.BaseType == typeof(EntityBase));

            var baseProperties = typeof(T).GetProperties().Where(p => IsValidType(p.PropertyType.BaseType));

            foreach (var property in baseProperties)
            {
                var propertyValue = GetPropValue(entity, property.Name) as EntityBase;
                var propertyEntity = _dbContext.Entry(propertyValue);
                if (propertyEntity.Entity.Id > 0)
                {
                    propertyEntity.CurrentValues.SetValues(propertyEntity);
                    propertyEntity.State = EntityState.Modified;
                }
                else
                {
                    propertyEntity.CurrentValues.SetValues(propertyEntity);
                    propertyEntity.State = EntityState.Added;
                }
            }
        }
    }
}