using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using TemplateApp.Data.Context;
using TemplateApp.Data.Models;

namespace TemplateApp.Data.Repositories
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private SarabiContext _context;

        public CurrencyRepository(SarabiContext context)
        {
            _context = context;
        }

        public bool Delete(Currency entity)
        {
            Currency Currency = _context.Currencies.First(s => s.Id == entity.Id);
            _context.Currencies.Remove(Currency);
            return _context.SaveChanges() == 1;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _context = null;
        }

        public IEnumerable<Currency> Find(Expression<Func<Currency, bool>> predicate)
        {
            return _context.Currencies.Where(predicate);
        }

        public Currency Get(int id)
        {
            Currency Currency = _context.Currencies.First(s => s.Id == id);
            return Currency;
        }

        public IQueryable<Currency> GetAll()
        {
            return _context.Currencies;
        }

        public bool Save(Currency entity)
        {
            if (entity.Id > 0)
            {
                Currency persistedCurrency = _context.Currencies.First(s => s.Id == entity.Id);
                _context.Entry<Currency>(persistedCurrency).CurrentValues.SetValues(entity);
            }
            else
            {
                _context.Currencies.Add(entity);
            }

            return _context.SaveChanges() == 1;
        }
    }
}