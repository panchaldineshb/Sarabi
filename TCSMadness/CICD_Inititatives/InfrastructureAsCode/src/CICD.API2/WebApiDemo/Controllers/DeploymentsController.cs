using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CICD.API2.Controllers
{
    [RoutePrefix("api/cicd/Deployments")]
    public class DeploymentsController : ApiController
    {
        protected IDeploymentsService _deploymentService = null;

        public DeploymentsController(
            IDeploymentsService deploymentService)
        {
            _deploymentService = deploymentService;
        }

        // GET api/Stuff

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return await Task.FromResult(Ok());
        }

        // POST api/Stuff

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]CryptoRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.Created,
                new CryptoReponse()
                {
                })));
        }

        private IHttpActionResult Try(Func<IHttpActionResult> action)
        {
            try
            {
                return action();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<IHttpActionResult> TryAsync(Func<Task<IHttpActionResult>> action)
        {
            try
            {
                return await action();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<IHttpActionResult> TryAsync(Func<IHttpActionResult> action, CancellationToken cancellationToken)
        {
            try
            {
                return await Task<IHttpActionResult>.Factory.StartNew(action, cancellationToken);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}