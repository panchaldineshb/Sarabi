using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;
using System;

namespace CICD.Infrastructure.Domain
{
    public class Node : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }

        public virtual Capability Capability { get; set; }

        public virtual Environment Environment { get; set; }

        public NodeType NodeType { get; set; }
    }
}
