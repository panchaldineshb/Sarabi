using FsaStore.WebSite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteUnitTester;

namespace FsaStore.Tests.Controllers
{
    [TestClass]
    public class RoutingTests
    {
        [TestMethod]
        public void TestIncomingRoutes()
        {
            // Arrange
            var tester = new RouteTester<MvcApplication>();

            // Act

            // Assert
            tester.WithIncomingRequest("/").ShouldMatchRoute("Home", "Index");
            tester.WithIncomingRequest("/Foo").ShouldMatchRoute("Foo", "Index");
            tester.WithIncomingRequest("/Foo/Index").ShouldMatchRoute("Foo", "Index");
            tester.WithIncomingRequest("/Foo/Bar").ShouldMatchRoute("Foo", "Bar");
            tester.WithIncomingRequest("/Foo/Bar/5").ShouldMatchRoute("Foo", "Bar", new { id = 5 });

            tester.WithIncomingRequest("/Foo/Bar/5/Baz").ShouldMatchNoRoute();

            tester.WithIncomingRequest("/handler.axd/pathInfo").ShouldBeIgnored();
        }

        [TestMethod]
        public void TestOutgoingRoutes()
        {
            // Arrange
            var tester = new RouteTester<MvcApplication>();

            // Assert
            tester.WithRouteInfo("Home", "Index").ShouldGenerateUrl("/");
            tester.WithRouteInfo("Home", "About").ShouldGenerateUrl("/Home/About");
            tester.WithRouteInfo("Home", "About", new { id = 5 }).ShouldGenerateUrl("/Home/About/5");
            tester.WithRouteInfo("Home", "About", new { id = 5, someKey = "someValue" }).ShouldGenerateUrl("/Home/About/5?someKey=someValue");
        }
    }
}