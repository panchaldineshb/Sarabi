using System;
using System.Linq;
using System.Linq.Expressions;

namespace FsaStore.Core.Abstracts
{
    /// <summary>
    /// Refer to following link for the example
    /// http://codereview.stackexchange.com/questions/11785/ef-code-first-with-repository-unitofwork-and-dbcontextfactory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        ///   Gets all objects from database
        /// </summary>
        IQueryable<T> All();

        /// <summary>
        ///   Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate"> Specified the filter expression </param>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Get the total objects count by specified filter.
        /// </summary>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Create a new object to database.
        /// </summary>
        /// <param name="entity"> Specified a new object to create. </param>
        T Create(T entity);

        /// <summary>
        ///   Deletes the object by primary key
        /// </summary>
        /// <param name="id"> </param>
        void Delete(object id);

        /// <summary>
        ///   Delete the object from database.
        /// </summary>
        /// <param name="entity"> Specified a existing object to delete. </param>
        void Delete(T entity);

        /// <summary>
        ///   Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"> </param>
        void Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate"> Specified a filter </param>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Gets objects from database with filting and paging.
        /// </summary>
        /// <param name="filter"> Specified a filter </param>
        /// <param name="total"> Returns the total records count of the filter. </param>
        /// <param name="index"> Specified the page index. </param>
        /// <param name="size"> Specified the page size </param>
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        ///   Find object by keys.
        /// </summary>
        /// <param name="keys"> Specified the search keys. </param>
        T Find(params object[] keys);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="predicate"> </param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> FindIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        ///   Gets objects via optional filter, sort order, and includes
        /// </summary>
        /// <param name="filter"> </param>
        /// <param name="orderBy"> </param>
        /// <param name="includeProperties"> </param>
        /// <returns> </returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        /// <summary>
        ///   Gets object by primary key.
        /// </summary>
        /// <param name="id"> primary key </param>
        /// <returns> </returns>
        T GetById(object id);

        /// <summary>
        ///   Save to database.
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();

        /// <summary>
        ///   Insert or Update object changes and save to database.
        /// </summary>
        /// <param name="entity"> Specified the object to save. </param>
        void Upsert(T entity);
    }
}