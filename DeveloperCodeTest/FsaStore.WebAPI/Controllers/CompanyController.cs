using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.WebAPI.Controllers
{
    public class CompanyController : ApiController
    {
        private IRepository<Company> CompanyRepository;
        private IRepository<SystemSetting> SystemSettingRepository;

        public CompanyController()
        {
            SystemSettingRepository = DependencyResolver.Current.GetService<IRepository<SystemSetting>>();
            CompanyRepository = DependencyResolver.Current.GetService<IRepository<Company>>();
        }

        public CompanyController(IRepository<SystemSetting> systemSettingRepository, IRepository<Company> companyRepository)
        {
            SystemSettingRepository = systemSettingRepository;
            CompanyRepository = companyRepository;
        }

        // DELETE api/Company/5
        public void Delete(int id)
        {
        }

        // GET api/Company
        public IEnumerable<Company> Get()
        {
            return new Company[] { };
        }

        // GET api/Company/5
        public Company Get(int id)
        {
            return new Company();
        }

        // POST api/Company
        public HttpResponseMessage Post([FromBody]Company value)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT api/Company/5
        public HttpResponseMessage Put(int id, [FromBody]Company value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}