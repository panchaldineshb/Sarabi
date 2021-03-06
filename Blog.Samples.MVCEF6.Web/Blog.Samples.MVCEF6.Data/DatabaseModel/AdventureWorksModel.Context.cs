﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog.Samples.MVCEF6.Data.DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    using System.Data.Entity.Core.Objects;
    using Blog.Samples.MVCEF6.Data.DataAcess;
    
    
    public partial class AdventureWorks2012Entities : DbContext, IDbContext
    {
        public AdventureWorks2012Entities()
            : base("name=AdventureWorks2012Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    	public ObjectContext ObjectContext
        {
            get { return this.GetObjectContext(); }
        }
    
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    
        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    	}
}
