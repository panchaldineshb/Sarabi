using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;

namespace CICD.Infrastructure.Domain
{
    public class CryptoReponse : IResponse<string>
    {
        public bool IsSuccessful { get; set; }

        public CryptoOperation CryptoOperation { get; set; }

        public string OutputString { get; set; }
    }
}