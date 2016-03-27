using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;
using System;

namespace CICD.Infrastructure.Domain
{
    public class User : ISubject
    {
        public User()
        {
            Type = SubjectType.User;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Infrastructure Infrastructure { get; set; }

        public LineOfBusiness LineOfBusiness { get; set; }

        public Capability Capability { get; set; }

        public SubjectType Type { get; set; }
    }

    public class Token : IEntity<int>
    {
        public Token()
        {
            Key = Guid.NewGuid().ToString();
        }

        public int Id { get; set; }

        public string Key { get; set; }

        public Application Application { get; set; }

        public User User { get; set; }
    }

    public class Policy : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}