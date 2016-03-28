﻿using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Blog.Samples.MVCEF6.Data.DataAcess
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    public static class DbContextExtensions
    {
        public static ObjectContext GetObjectContext(this IDbContext dbContext)
        {
            return ((IObjectContextAdapter)dbContext).ObjectContext;
        }
    }
}
