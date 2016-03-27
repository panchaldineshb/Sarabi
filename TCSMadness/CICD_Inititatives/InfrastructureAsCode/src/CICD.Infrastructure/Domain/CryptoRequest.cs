using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Enums;

namespace CICD.Infrastructure.Domain
{
    public class CryptoRequest : IRequest
    {
        public CryptoOperation CryptoOperation { get; set; }

        public string InputString { get; set; }
    }
}