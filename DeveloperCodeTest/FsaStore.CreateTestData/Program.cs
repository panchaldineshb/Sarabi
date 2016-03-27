using System;
using System.Data.Entity;
using FsaStore.Core.Abstracts;
using FsaStore.Core.Concrete;
using FsaStore.Core.Context;
using FsaStore.Core.Extensions;
using FsaStore.Core.Models;
using Microsoft.GotDotNet;
using Ninject;

namespace FsaStore.CreateTestData
{
    internal class Program
    {
        private static void createAccountProfiles()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<AccountProfile>>().To<Repository<AccountProfile>>();
                kernel.Bind<IRepository<Account>>().To<Repository<Account>>();
                kernel.Bind<IRepository<Role>>().To<Repository<Role>>();

                var accountProfileRepository = kernel.Get<IRepository<AccountProfile>>();
                var accountRepository = kernel.Get<IRepository<Account>>();
                var roleRepository = kernel.Get<IRepository<Role>>();

                accountProfileRepository.Upsert(new AccountProfile
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Account = accountRepository.Find(c => c.Name == "Tester A"),
                    Role = roleRepository.Find(c => c.Name == "A/B Testing"),
                    Name = "Tester A Profile",
                    DisplayName = "Tester A Profile",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountProfileRepository.Upsert(new AccountProfile
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Account = accountRepository.Find(c => c.Name == "Tester B"),
                    Role = roleRepository.Find(c => c.Name == "A/B Testing"),
                    Name = "Tester B Profile",
                    DisplayName = "Tester B Profile",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountProfileRepository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine("Accounts created");
            }
        }

        private static void createAccounts()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<Account>>().To<Repository<Account>>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();
                kernel.Bind<IRepository<Role>>().To<Repository<Role>>();

                var accountRepository = kernel.Get<IRepository<Account>>();
                var companyRepository = kernel.Get<IRepository<Company>>();
                var roleRepository = kernel.Get<IRepository<Role>>();

                accountRepository.Upsert(new Account
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Superuser",
                    DisplayName = "We!come",
                    Firstname = "Super",
                    Lastname = "User",
                    Password = accountRepository.Encode("Tester!A"),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountRepository.Upsert(new Account
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Billing Manager",
                    DisplayName = "We!come",
                    Firstname = "Billing",
                    Lastname = "Manager",
                    Password = accountRepository.Encode("Tester!A"),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountRepository.Upsert(new Account
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "QC Manager",
                    DisplayName = "We!come",
                    Firstname = "QC",
                    Lastname = "Manager",
                    Password = accountRepository.Encode("Tester!A"),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountRepository.Upsert(new Account
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Tester A",
                    DisplayName = "Tester A",
                    Firstname = "Tester",
                    Lastname = "A",
                    Password = accountRepository.Encode("Tester!A"),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountRepository.Upsert(new Account
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Tester B",
                    DisplayName = "Tester B",
                    Firstname = "Tester",
                    Lastname = "B",
                    Password = accountRepository.Encode("Tester!B"),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                accountRepository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine("Accounts created");
            }
        }

        private static void createCompany()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();

                var repository = kernel.Get<IRepository<Company>>();

                var companyExists = repository.Find(c => c.Name == "Sarabi LLC");
                if (companyExists != null) return;

                var company = new Company
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Sarabi LLC",
                    DisplayName = "Sarabi LLC",
                    Email = "panchaldineshb@gmail.com",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };
                repository.Upsert(company);
                repository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCompanySystemSettings()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<SystemSetting>>().To<Repository<SystemSetting>>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();

                var companyRepository = kernel.Get<IRepository<Company>>();
                var systemSettingsRepository = kernel.Get<IRepository<SystemSetting>>();

                systemSettingsRepository.Upsert(new SystemSetting
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Pharmaceutical",
                    DisplayName = "Pharmaceutical",
                    Key = "DefaultProfileAllowed",
                    Value = "1",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                systemSettingsRepository.Upsert(new SystemSetting
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Pharmaceutical",
                    DisplayName = "Pharmaceutical",
                    Key = "DefaultProfileName",
                    Value = "A/B Testing",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                systemSettingsRepository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(systemSettingsRepository.Find(c => c.Name == "Pharmaceutical").Name);
            }
        }

        private static void createProductGroup()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<ProductGroup>>().To<Repository<ProductGroup>>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();

                var companyRepository = kernel.Get<IRepository<Company>>();
                var productGroupRepository = kernel.Get<IRepository<ProductGroup>>();

                productGroupRepository.Upsert(new ProductGroup
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Pharmaceutical",
                    DisplayName = "Pharmaceutical",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                productGroupRepository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(productGroupRepository.Find(c => c.Name == "Pharmaceutical").Name);
            }
        }

        private static void createProducts()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<ProductGroup>>().To<Repository<ProductGroup>>();
                kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();

                var companyRepository = kernel.Get<IRepository<Company>>();
                var productGroupRepository = kernel.Get<IRepository<ProductGroup>>();
                var productRepository = kernel.Get<IRepository<Product>>();

                productRepository.Upsert(new Product
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    ProductGroup = productGroupRepository.Find(c => c.Name == "Pharmaceutical"),
                    Name = "Apsrin",
                    DisplayName = "Apsrin",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });

                productRepository.Upsert(new Product
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    ProductGroup = productGroupRepository.Find(c => c.Name == "Pharmaceutical"),
                    Name = "First Aid Kit",
                    DisplayName = "First Aid Kit",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });

                productRepository.Upsert(new Product
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    ProductGroup = productGroupRepository.Find(c => c.Name == "Pharmaceutical"),
                    Name = "Thermometer",
                    DisplayName = "Thermometer",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });

                productRepository.Upsert(new Product
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    ProductGroup = productGroupRepository.Find(c => c.Name == "Pharmaceutical"),
                    Name = "Advil",
                    DisplayName = "Advil",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });

                productRepository.Upsert(new Product
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    ProductGroup = productGroupRepository.Find(c => c.Name == "Pharmaceutical"),
                    Name = "Bandage",
                    DisplayName = "Bandage",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                productRepository.SaveChanges();
            }
        }

        private static void createPromotionCodes()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<PromotionCode>>().To<Repository<PromotionCode>>();
                kernel.Bind<IRepository<SalesCampaign>>().To<Repository<SalesCampaign>>();

                var salesCampaign = kernel.Get<IRepository<SalesCampaign>>();
                var repository = kernel.Get<IRepository<PromotionCode>>();

                var promotionCode = new PromotionCode
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Campaign = salesCampaign.Find(c => c.Name == "Compaign 2013"),
                    Name = "Promo 40",
                    DisplayName = "Promo 40",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };
                repository.Upsert(promotionCode);
                repository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(promotionCode.Name);
            }
        }

        private static void createRoles()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<Role>>().To<Repository<Role>>();

                var roleRepository = kernel.Get<IRepository<Role>>();

                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "User",
                    DisplayName = "User",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Administrator",
                    DisplayName = "Administrator",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Billing",
                    DisplayName = "Billing",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Human Resources",
                    DisplayName = "Human Resources",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Quality Control",
                    DisplayName = "Quality Control",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "A/B Testing",
                    DisplayName = "A/B Testing",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.Upsert(new Role
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Name = "Manager",
                    DisplayName = "Manager",
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                });
                roleRepository.SaveChanges();
            }
        }

        private static void createSalesCompaign()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<DbContext>().To<DomainContext>();
                kernel.Bind<IRepository<SalesCampaign>>().To<Repository<SalesCampaign>>();
                kernel.Bind<IRepository<Company>>().To<Repository<Company>>();

                var companyRepository = kernel.Get<IRepository<Company>>();
                var repository = kernel.Get<IRepository<SalesCampaign>>();

                var salesCampaign = new SalesCampaign
                {
                    Active = 1,
                    Locked = 0,
                    Visible = 1,
                    Company = companyRepository.Find(c => c.Name == "Sarabi LLC"),
                    Name = "Compaign 2013",
                    DisplayName = "Compaign 2013",
                    Start = DateTime.Now.ToUniversalTime(),
                    End = DateTime.Now.AddDays(10).ToUniversalTime(),
                    ExternalId = Guid.NewGuid(),
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };
                repository.Upsert(salesCampaign);
                repository.SaveChanges();

                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(salesCampaign.Name);
            }
        }
        private static void Main(string[] args)
        {
            createCompany();
            createCompanySystemSettings();

            createSalesCompaign();
            createPromotionCodes();

            createProductGroup();
            createProducts();

            createRoles();
            createAccounts();
            createAccountProfiles();

            ConsoleEx.TextColor(ConsoleForeground.Green, ConsoleBackground.Black);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}