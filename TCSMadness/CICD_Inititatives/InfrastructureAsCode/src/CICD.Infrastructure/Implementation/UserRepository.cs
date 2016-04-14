using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using CICD.Infrastructure.Database;

namespace CICD.Infrastructure.Implementation

{
    public class UserRepository : IUserRepository
    {

        private readonly InfrastructureContext _context;

        public UserRepository(InfrastructureContext context)
        {
            _context = context;
        }

        private const string key = "UserS";

        private IDictionary<int, User> Subjects
        {
            get;
            set;
        }

        public IEnumerable<User> GetAll()
        {
            return Subjects.Values.AsEnumerable();
        }


        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public User GetById(int id)
        {
            return Subjects[1];
        }

        public void Add(User item)
        {
            //var nextKey = Subjects.Values.Max(v => v.Id) + 1;
            //item.Id = nextKey;
            //Subjects.Add(nextKey, item);

            item.Id = _context.Users.Count() + 1;
            _context.Users.Add(item);
        }

        public void Delete(User item)
        {
            Subjects.Remove(item.Id);
        }

        public void Update(User item)
        {
            Subjects[item.Id] = item;
        }
    }
}