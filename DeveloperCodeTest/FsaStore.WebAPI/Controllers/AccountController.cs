using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Models;
using FsaStore.Core.ViewModels;
using FsaStore.WebAPI.Mappers;

namespace FsaStore.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        private AccountMapper AccountMapper;
        private IRepository<Account> AccountRepository;

        private IRepository<Company> CompanyRepository;

        private IRepository<SystemSetting> SystemSettingRepository;

        public AccountController()
        {
            SystemSettingRepository = DependencyResolver.Current.GetService<IRepository<SystemSetting>>();
            CompanyRepository = DependencyResolver.Current.GetService<IRepository<Company>>(); ;
            AccountRepository = DependencyResolver.Current.GetService<IRepository<Account>>();
            AccountMapper = DependencyResolver.Current.GetService<AccountMapper>();
        }

        public AccountController(IRepository<SystemSetting> systemSettingRepository, IRepository<Company> companyRepository, IRepository<Account> accountRepository, AccountMapper accountMapper)
        {
            SystemSettingRepository = systemSettingRepository;
            CompanyRepository = companyRepository;
            AccountRepository = accountRepository;
            AccountMapper = accountMapper;
        }

        // DELETE api/Account/5
        public void Delete(int id)
        {
        }

        // GET api/Account
        public IEnumerable<Account> Get()
        {
            return new Account[] { };
        }

        // GET api/Account/5
        public Account Get(int id)
        {
            return new Account();
        }

        // POST api/Account
        public HttpResponseMessage Post([FromBody]RegistrationViewModel value)
        {
            // add an account
            var input = AccountMapper.Resolve(value);
            var account = AccountRepository.Create(input);
            AccountRepository.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + account.Id.ToString());

            return response;
        }

        // PUT api/Account/5
        public HttpResponseMessage Put(int id, [FromBody]Account value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}