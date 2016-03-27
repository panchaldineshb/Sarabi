using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.WebAPI.Controllers
{
    public class ShoppingController : ApiController
    {
        private IRepository<Account> AccountRepository;

        public ShoppingController()
        {
            // Refer -- http://stackoverflow.com/questions/6519720/using-ninject-with-a-custom-role-provider-in-an-mvc3-app
            AccountRepository = DependencyResolver.Current.GetService<IRepository<Account>>();
        }

        public ShoppingController(IRepository<Account> accountRepository)
        {
            AccountRepository = accountRepository;
        }

        // DELETE api/Shopping/5
        public void Delete(int id)
        {
        }

        // GET api/Shopping
        public IEnumerable<Product> Get()
        {
            return new Product[] { };
        }

        // GET api/Shopping/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Shopping
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT api/Shopping/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}