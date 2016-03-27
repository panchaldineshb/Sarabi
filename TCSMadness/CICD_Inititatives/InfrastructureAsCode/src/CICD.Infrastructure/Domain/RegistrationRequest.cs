using CICD.Infrastructure.Abstraction;

namespace CICD.Infrastructure.Domain
{
    public class RegistrationRequest : IRequest
    {
        public ISubject Subject { get; set; }
    }
}