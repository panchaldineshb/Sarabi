using CICD.Infrastructure.Enums;

namespace CICD.Infrastructure.Abstraction
{
    public interface ISubject : IEntity<int>
    {
        SubjectType Type { get; set; }
    }
}