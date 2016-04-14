using CICD.Infrastructure.Abstraction;
using CICD.Infrastructure.Domain;
using CICD.Infrastructure.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CICD.API2.Controllers
{
    [RoutePrefix("api/cicd/registrations")]
    public class RegistrationsController : ApiController
    {
        protected IRegistrationsService _registrationsService = null;
        protected IUserRepository _userRepository = null;

        public RegistrationsController(
            IRegistrationsService registrationsService, IUserRepository userRepository)
        {
            _registrationsService = registrationsService;
            _userRepository = userRepository;
        }

        // GET api/Stuff
        //
        // Based upon tokenKey, check in both tables Applications and Users
        // which ever table got the key send response back being sucessful

        [Route("{token}")]
        public async Task<IHttpActionResult> Get(string token)
        {
            if(_registrationsService.ValidateToken(token)) return await Task.FromResult(Ok());
            return await Task.FromResult(new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.NotFound,
                new RegistrationReponse()
                {
                    IsSuccessful = false,
                    ErrorMessage = "Provided token doesnot exists"
                })));
        }

        //
        // POST api/registrations
        //
        // Create User and send tokenKey
        // Create Application and send tokenKey

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(RegistrationRequest request)
        {
            string tokenKey = string.Empty;
            try
            {
                switch (request.RegistrationType)
                {
                    case SubjectType.User:
                        tokenKey =  _registrationsService.AddUser(request.User);
                        break;
                    case SubjectType.Application:
                        tokenKey = _registrationsService.AddApplication(request.Application);
                        break;
                    case SubjectType.Device:
                        break;
                }

                return await Task.FromResult(new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.Created,
                    new RegistrationReponse()
                    {
                        IsSuccessful = true,
                        TokenKey = tokenKey
                    })));
            }
            catch(Exception ex)
            {
                return await Task.FromResult(new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.BadRequest,
                   new RegistrationReponse()
                   {
                       IsSuccessful = false,
                       ErrorMessage = "Error in registration. " + ex.Message
                   })));
            }
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