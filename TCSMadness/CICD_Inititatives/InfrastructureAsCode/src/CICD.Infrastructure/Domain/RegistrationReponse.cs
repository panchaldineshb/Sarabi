using CICD.Infrastructure.Abstraction;

namespace CICD.Infrastructure.Domain
{
    public class RegistrationReponse : IResponse<ISubject>
    {
        public bool IsSuccessful { get; set; }

        public ISubject Subject { get; set; }
    }
}