using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CICD.API2.Controllers
{
    [RoutePrefix("api/cicd/crypto")]
    public class CryptoController : ApiController
    {
        protected ICryptoService _cryptoService = null;

        public CryptoController(
            ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        // GET api/crypto

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return await Task.FromResult(Ok());
        }

        // POST api/crypto

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]CryptoRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.Created,
                new CryptoReponse()
                {
                })));
        }
    }
}