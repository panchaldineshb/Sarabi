using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FsaStore.Core.Concrete;
using FsaStore.Core.Context;
using FsaStore.Core.Models;
using FsaStore.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsaStore.Tests.Controllers
{
    [TestClass]
    public class ShoppingControllerTests
    {
        [TestMethod]
        public void Delete()
        {
            // Arrange
            DbContext dbContext = new DomainContext();
            var accountRepository = new Repository<Account>(dbContext);
            var controller = new ShoppingController(accountRepository);

            // Act
            controller.Delete(5);

            // Assert
        }

        [TestMethod]
        public void Get()
        {
            // Arrange
            DbContext dbContext = new DomainContext();
            var accountRepository = new Repository<Account>(dbContext);
            var controller = new ShoppingController(accountRepository);

            // Act
            IEnumerable<Product> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            DbContext dbContext = new DomainContext();
            var accountRepository = new Repository<Account>(dbContext);
            var controller = new ShoppingController(accountRepository);

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            DbContext dbContext = new DomainContext();
            var accountRepository = new Repository<Account>(dbContext);
            var controller = new ShoppingController(accountRepository);

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            DbContext dbContext = new DomainContext();
            var accountRepository = new Repository<Account>(dbContext);
            var controller = new ShoppingController(accountRepository);

            // Act
            controller.Put(5, "value");

            // Assert
        }
    }
}