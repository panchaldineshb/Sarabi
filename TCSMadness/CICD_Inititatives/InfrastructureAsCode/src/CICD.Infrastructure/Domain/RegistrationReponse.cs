using CICD.Infrastructure.Abstraction;

namespace CICD.Infrastructure.Domain
{
    public class RegistrationReponse : IResponse<string>
    {
        public bool IsSuccessful { get; set; }

        public string TokenKey { get; set; }
    }
}