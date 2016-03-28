using CICD.Infrastructure.Abstraction;

namespace CICD.Infrastructure.Domain
{
    public class RegistrationRequest : IRequest
    {
        public User User { get; set; }

        public Application Application { get; set; }
    }
}