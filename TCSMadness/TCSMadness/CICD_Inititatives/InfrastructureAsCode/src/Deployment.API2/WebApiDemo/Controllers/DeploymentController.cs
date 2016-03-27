using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Deployment.API2.Controllers
{
    [RoutePrefix("api/deployment")]
    public class DeploymentController : ApiController
    {
        // GET api/deployment

        [Route("")]
        public Task<HttpResponseMessage> Get()
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return Task<HttpResponseMessage>.Factory.StartNew(responseFunc);
        }

        // GET api/deployment/5

        [Route("{id:int}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return Task<HttpResponseMessage>.Factory.StartNew(responseFunc);
        }

        // POST api/deployment

        [Route("")]
        public Task<HttpResponseMessage> Post(int id, CancellationToken cancellationToken)
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return Task<HttpResponseMessage>.Factory.StartNew(responseFunc, cancellationToken);
        }
    }
}