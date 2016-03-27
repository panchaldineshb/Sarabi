using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;
using System;

namespace CICD.Infrastructure.Domain
{
    public class Infrastructure : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class LineOfBusiness : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }
    }

    public class Capability : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }
    }

    public class Release : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }

        public virtual Capability Capability { get; set; }
    }

    public class Environment : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }
    }

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

    public class Application : ISubject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }

        public virtual Capability Capability { get; set; }

        public SubjectType Type { get; set; }
    }

    public class Artifact : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ArtifactType ArtifactType { get; set; }

        public virtual Application Application { get; set; }
    }

    public class Build : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string MajorVersion { get; set; }
        public string MinorVersion { get; set; }

        public virtual Infrastructure Infrastructure { get; set; }

        public virtual LineOfBusiness LineOfBusiness { get; set; }

        public virtual Capability Capability { get; set; }

        public virtual Environment Environment { get; set; }

        public virtual Release Release { get; set; }

        public Application Application { get; set; }
    }

    public class BuildArtifact : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Artifact Artifact { get; set; }

        public virtual Build Build { get; set; }
    }

    public class BuildNode : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Build Build { get; set; }

        public virtual User Node { get; set; }
    }
}