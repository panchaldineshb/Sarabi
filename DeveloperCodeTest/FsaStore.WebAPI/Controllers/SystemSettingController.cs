using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;

namespace FsaStore.WebAPI.Controllers
{
    public class SystemSettingController : ApiController
    {
        private IRepository<SystemSetting> SystemSettingRepository;

        public SystemSettingController()
        {
            SystemSettingRepository = DependencyResolver.Current.GetService<IRepository<SystemSetting>>();
        }

        public SystemSettingController(IRepository<SystemSetting> systemSettingRepository)
        {
            SystemSettingRepository = systemSettingRepository;
        }

        // DELETE api/SystemSetting/5
        public void Delete(int id)
        {
        }

        // GET api/SystemSetting
        public IEnumerable<SystemSetting> Get()
        {
            return new SystemSetting[] { };
        }

        // GET api/SystemSetting/5
        public SystemSetting Get(int id)
        {
            return new SystemSetting();
        }

        // POST api/SystemSetting
        public HttpResponseMessage Post([FromBody]SystemSetting value)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT api/SystemSetting/5
        public HttpResponseMessage Put(int id, [FromBody]SystemSetting value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}