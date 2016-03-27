using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Extensions;
using FsaStore.Core.Models;
using FsaStore.Core.ViewModels;

namespace FsaStore.WebAPI.Mappers
{
    public class AccountMapper
    {
        private IRepository<Account> AccountRepository;
        private IRepository<Company> CompanyRepository;

        public AccountMapper()
        {
            AccountRepository = DependencyResolver.Current.GetService<IRepository<Account>>();
            CompanyRepository = DependencyResolver.Current.GetService<IRepository<Company>>();

            Mapper.CreateMap<RegistrationViewModel, Account>().ConvertUsing(r =>
            {
                return new Account()
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = CompanyRepository.Find(c => c.Id == r.CompanyId),
                    Name = string.Format("{0} {1}", r.Firstname, r.Lastname),
                    DisplayName = string.Format("{0} {1}", r.Firstname, r.Lastname),
                    Firstname = r.Firstname,
                    Lastname = r.Lastname,
                    Location = new Location { Street = r.Street },
                    Email = r.Email,
                    Phone = r.Phone,
                    SecondPhone = r.SecondPhone,
                    Password = AccountRepository.Encode(r.Password),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };
            });

            Mapper.CreateMap<Account, RegistrationViewModel>().ConvertUsing(a =>
            {
                return new RegistrationViewModel()
                {
                    CompanyId = a.Id,
                    Companies = CompanyRepository.All().ToList(),
                    Firstname = a.Firstname,
                    Lastname = a.Lastname,
                    Street = a.Location.Street,
                    Email = a.Email,
                    Phone = a.Phone,
                    SecondPhone = a.SecondPhone,
                    Password = AccountRepository.Encode(a.Password)
                };
            });
        }

        public Account Resolve(RegistrationViewModel source)
        {
            return Mapper.Map<RegistrationViewModel, Account>(source);
        }

        public RegistrationViewModel Resolve(Account source)
        {
            return Mapper.Map<Account, RegistrationViewModel>(source);
        }
    }
}