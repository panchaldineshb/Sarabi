using System;
using System.Linq;
using Microsoft.GotDotNet;
using Ninject;
using TemplateApp.Data.Models;
using TemplateApp.Data.Repositories;

namespace TemplateApp.CreateTestData
{
    internal class Program
    {
        private static void createCompanyCustomers()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IRepository<Company>>()
                      .To<CompanyRepository>();

                var repository = kernel.Get<IRepository<Company>>();
                var company = repository.Find(c => c.Name == "Sarabi LLC").SingleOrDefault();
                ConsoleEx.TextColor(ConsoleForeground.Yellow, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCompanyLocations()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IRepository<Company>>().To<CompanyRepository>();
                kernel.Bind<IRepository<Currency>>().To<CurrencyRepository>();

                var repository = kernel.Get<IRepository<Company>>();

                var location_39_Henry_St = new Location
                {
                    Active = 1,
                    Name = "Corporate Address",
                    DisplayName = "Corporate Address",
                    Address = "39 Henry St",
                    City = "Edison",
                    StateCode = "NJ",
                    ZipCode = "08820",
                    CountryCode = "U.S.A",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                var location_188_Parsonage_Rd = new Location
                {
                    Active = 1,
                    Name = "Warehouse Address",
                    DisplayName = "Warehouse Address",
                    Address = "188 Parsonage Rd",
                    City = "Edison",
                    StateCode = "NJ",
                    ZipCode = "08820",
                    CountryCode = "U.S.A",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                var company = new Company
                {
                    Active = 1,
                    Name = "Sarabi LLC",
                    DisplayName = "Sarabi LLC",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                /*
                var currency = kernel.Get<IRepository<Currency>>().Find(c => c.Name == "Indian Rupees").Single();
                */

                var currency = new Currency
                {
                    Active = 1,
                    Name = "Euro",
                    DisplayName = "Euro",
                    Sign = "EUR",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                company.Currency = currency;

                company.Locations.Add(location_39_Henry_St); company.Locations.Add(location_188_Parsonage_Rd);

                repository.Save(company);
                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCompanyPermissions()
        {
            using (var kernel = new StandardKernel(new CreateTestDataModule()))
            {
                var repository = kernel.Get<IRepository<Company>>();
                var company = repository.Find(c => c.Name == "Sarabi LLC").SingleOrDefault();
                ConsoleEx.TextColor(ConsoleForeground.Aquamarine, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCompanyRoles()
        {
            using (var kernel = new StandardKernel(new CreateTestDataModule()))
            {
                var repository = kernel.Get<IRepository<Company>>();
                var company = repository.Find(c => c.Name == "Sarabi LLC").SingleOrDefault();
                ConsoleEx.TextColor(ConsoleForeground.Blue, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCompanyUsers()
        {
            using (var kernel = new StandardKernel(new CreateTestDataModule()))
            {
                var repository = kernel.Get<IRepository<Company>>();
                var company = repository.Find(c => c.Name == "Sarabi LLC").SingleOrDefault();
                ConsoleEx.TextColor(ConsoleForeground.Aquamarine, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }

        private static void createCurrencies()
        {
            using (var kernel = new StandardKernel(new CreateTestDataModule()))
            {
                var repository = kernel.Get<IRepository<Currency>>();

                var USDollar = new Currency
                {
                    Active = 1,
                    Name = "US Dollar",
                    DisplayName = "US Dollar",
                    Sign = "$",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                var IndianRupees = new Currency
                {
                    Active = 1,
                    Sign = "$",
                    Name = "Indian Rupees",
                    DisplayName = "Indian Rupees",
                    UpdatedUtc = DateTime.Now.ToUniversalTime(),
                    CreatedUtc = DateTime.Now.ToUniversalTime()
                };

                repository.Save(USDollar); repository.Save(IndianRupees);

                // Update currency Sign
                var currency = repository.Find(c => c.Name == "Indian Rupees").SingleOrDefault();
                currency.Sign = "R$";
                repository.Save(IndianRupees);
                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(IndianRupees.Sign);
            }
        }

        private static void Main(string[] args)
        {
            createCurrencies();

            createCompanyLocations();
            createCompanyUsers();
            createCompanyCustomers();

            updateCompanyLocations();

            ConsoleEx.TextColor(ConsoleForeground.Green, ConsoleBackground.Black);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private static void updateCompanyLocations()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IRepository<Company>>().To<CompanyRepository>();
                kernel.Bind<IRepository<Currency>>().To<CurrencyRepository>();

                var repository = kernel.Get<IRepository<Company>>();

                var company = repository.Find(c => c.Name == "Sarabi LLC").SingleOrDefault();
                var location = company.Locations.ToList<Location>().SingleOrDefault<Location>(l => l.Address == "188 Parsonage Rd");
                location.ZipCode = "08837";
                repository.Save(company);
                ConsoleEx.TextColor(ConsoleForeground.Maroon, ConsoleBackground.Black);
                Console.WriteLine(company.Name);
            }
        }
    }
}