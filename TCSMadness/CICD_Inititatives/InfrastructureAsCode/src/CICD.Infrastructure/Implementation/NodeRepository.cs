using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Database;
using CICD.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace CICD.Infrastructure.Implementation

{
    public class NodeRepository : INodeRepository
    {
        private readonly InfrastructureContext _context;

        public NodeRepository(InfrastructureContext context)
        {
            _context = context;
        }

        private const string key = "Nodes";

        private IDictionary<int, Node> Subjects
        {
            get;
            set;
        }
        
        public IEnumerable<Node> GetAll()
        {
            return Subjects.Values.AsEnumerable();
        }


        public IEnumerable<Node> FindBy(Expression<Func<Node, bool>> predicate)
        {
            return _context.Nodes.Where(predicate);
        }

        public Node GetById(int id)
        {
            return Subjects[1];
        }

        public void Add(Node item)
        {
            //var nextKey = Subjects.Values.Max(v => v.Id) + 1;
            //item.Id = nextKey;
            //Subjects.Add(nextKey, item);

            item.Id = _context.Nodes.Count() + 1;
            _context.Nodes.Add(item);
        }

        public void Delete(Node item)
        {
            Subjects.Remove(item.Id);
        }

        public void Update(Node item)
        {
            Subjects[item.Id] = item;
        }
    }
}