using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;

namespace CICD.Infrastructure.Domain
{
    public class RegistrationRequest : IRequest
    {
        public SubjectType RegistrationType { get; set; }

    public User User { get; set; }

        public Application Application { get; set; }
    }
}