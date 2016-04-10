using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Database;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace CICD.Infrastructure.Implementation

{
    public class TokenRepository : ITokenRepository
    {
        //private readonly InfrastructureContext _context;
        private InfrastructureContext _context;

        public TokenRepository(InfrastructureContext context)
        {
            _context = context;
        }

        public IEnumerable<Token> GetAll()
        {
            return _context.Tokens.AsEnumerable();
        }

        public IEnumerable<Token> FindBy(Expression<Func<Token, bool>> predicate)
        {
            return _context.Tokens.Where(predicate);
        }

        public Token GetById(int id)
        {
            return _context.Tokens.Where(t => t.Id == id).Single();
        }

        public void Add(Token item)
        {
            _context.Tokens.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Token item)
        {
            _context.Tokens.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Token item)
        {
            var entity = _context.Tokens.SingleOrDefault(t => t.Id == item.Id);

            _context.Tokens.Attach(entity);

            _context.SaveChanges();
        }
    }
}