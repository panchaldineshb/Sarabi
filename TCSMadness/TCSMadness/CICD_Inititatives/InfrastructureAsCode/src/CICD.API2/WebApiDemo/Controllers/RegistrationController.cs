using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CICD.API2.Controllers
{
    [RoutePrefix("api/cicd/registration")]
    public class RegistrationController : ApiController
    {
        // GET api/registration

        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return await Task<HttpResponseMessage>.Factory.StartNew(responseFunc);
        }

        // GET api/registration/5

        [Route("{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return await Task<HttpResponseMessage>.Factory.StartNew(responseFunc);
        }

        // POST api/registration

        [Route("")]
        public async Task<HttpResponseMessage> Post(int id, CancellationToken cancellationToken)
        {
            Func<HttpResponseMessage> responseFunc = () => new HttpResponseMessage();
            return await Task<HttpResponseMessage>.Factory.StartNew(responseFunc, cancellationToken);
        }
    }
}