using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using TemplateApp.Data.Context;
using TemplateApp.Data.Models;

namespace TemplateApp.Data.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private SarabiContext _context;

        public CompanyRepository(SarabiContext context)
        {
            _context = context;
        }

        public bool Delete(Company entity)
        {
            Company company = _context.Companies.First(s => s.Id == entity.Id);
            _context.Companies.Remove(company);
            return _context.SaveChanges() == 1;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _context = null;
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate)
        {
            return _context.Companies.Where(predicate);
        }

        public Company Get(int id)
        {
            Company company = _context.Companies.First(s => s.Id == id);
            return company;
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies;
        }

        public bool Save(Company entity)
        {
            if (entity.Id > 0)
            {
                Company persistedCompany = _context.Companies.First(s => s.Id == entity.Id);
                _context.Entry<Company>(persistedCompany).CurrentValues.SetValues(entity);
            }
            else
            {
                // Refer to article : 
                // http://msdn.microsoft.com/en-us/magazine/dn166926.aspx
                // http://stackoverflow.com/questions/3920111/entity-framework-4-addobject-vs-attach
                // I had to call Attach since it was adding new currency as well
                _context.Companies.Add(entity);

                // Attach is used for entities that already exist in the database. 
                foreach (var location in entity.Locations)
                    if (location.Id > 0)
                        _context.Locations.Attach(location);

                // Attach is used for entities that already exist in the database. 
                if (entity.Currency.Id > 0)
                    _context.Currencies.Attach(entity.Currency);
            }

            return _context.SaveChanges() == 1;
        }
    }
}