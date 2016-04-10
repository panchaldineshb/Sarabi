using System;
using System.Linq;

namespace CICD.Initialize.Database
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initialize database?");
            bool init = Console.ReadLine().ToUpper() == "Y";
            if (init) SeedData();
            Console.WriteLine("Query database?");
            bool query = Console.ReadLine().ToUpper() == "Y";
            if (query) QueryData();
            Console.WriteLine("Lazy loading?");
            bool lazy = Console.ReadLine().ToUpper() == "Y";
            if (lazy) LazyLoading();
        }

        private static void SeedData()
        {
            using (var context = new SampleContext())
            {
                //
                // Create infrastructures
                //
                var infrastructure = context.Infrastructures.Add(new CICD.Infrastructure.Domain.Infrastructure
                {
                    Name = "SM-eCommerce"
                });

                var cardProcessing = context.LineOfBusinesses.Add(new CICD.Infrastructure.Domain.LineOfBusiness
                {
                    Name = "SM-Card Processing",
                    Infrastructure = infrastructure
                });

                var warehouse = context.LineOfBusinesses.Add(new CICD.Infrastructure.Domain.LineOfBusiness
                {
                    Name = "SM-Warehouse",
                    Infrastructure = infrastructure
                });

                var cardProcessingNYC = context.Capabilities.Add(new CICD.Infrastructure.Domain.Capability
                {
                    Name = "SM-Card Processing(NYC)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = cardProcessing
                });

                var cardProcessingLA = context.Capabilities.Add(new CICD.Infrastructure.Domain.Capability
                {
                    Name = "SM-Card Processing(LA)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = cardProcessing
                });

                var cardProcessingDC = context.Capabilities.Add(new CICD.Infrastructure.Domain.Capability
                {
                    Name = "SM-Card Processing(DC)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = cardProcessing
                });

                var warehouseNYC = context.Capabilities.Add(new CICD.Infrastructure.Domain.Capability
                {
                    Name = "SM-Warehouse(NYC)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                var warehouseSeatle = context.Capabilities.Add(new CICD.Infrastructure.Domain.Capability
                {
                    Name = "SM-Warehouse(Seatle)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                // Environments
                var cardProcessing_Development = context.Environments.Add(new CICD.Infrastructure.Domain.Environment
                {
                    Name = "SM-Card Processing (Development)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                var cardProcessing_Production = context.Environments.Add(new CICD.Infrastructure.Domain.Environment
                {
                    Name = "SM-Card Processing (Production)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                var cardProcessing_SE = context.Environments.Add(new CICD.Infrastructure.Domain.Environment
                {
                    Name = "SM-Card Processing (SE)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                var cardProcessing_QA = context.Environments.Add(new CICD.Infrastructure.Domain.Environment
                {
                    Name = "SM-Card Processing (QA)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse
                });

                // Releases
                var cardProcessingNYCR1 = context.Releases.Add(new CICD.Infrastructure.Domain.Release
                {
                    Name = "SM-Card Processing(NYC) Release-1(R1)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = cardProcessing,
                    Capability = cardProcessingNYC,
                    StartDate = DateTime.Today.AddDays(-7),
                    EndDate = DateTime.Today.AddDays(+27)
                });

                var cardProcessingLAR4 = context.Releases.Add(new CICD.Infrastructure.Domain.Release
                {
                    Name = "SM-Card Processing(LA) Release-4(R4)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = cardProcessing,
                    Capability = cardProcessingLA,
                    StartDate = DateTime.Today.AddDays(-17),
                    EndDate = DateTime.Today.AddDays(+47)
                });

                // Nodes
                var node_Development = context.Nodes.Add(new CICD.Infrastructure.Domain.Node
                {
                    Name = "SM-Card Processing (DevBox) (Development)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse,
                    Capability = cardProcessingLA,
                    Environment = cardProcessing_Development,
                    NodeType = Infrastructure.Enums.NodeType.API
                });

                var node_Production = context.Nodes.Add(new CICD.Infrastructure.Domain.Node
                {
                    Name = "SM-Card Processing (ProdBox) (Production)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse,
                    Capability = cardProcessingLA,
                    Environment = cardProcessing_Production,
                    NodeType = Infrastructure.Enums.NodeType.API
                });

                // Users
                var user_smCardProcessing = context.Users.Add(new CICD.Infrastructure.Domain.User
                {
                    Name = "SM-Card Processing (ProdBox) (Production)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse,
                    Capability = cardProcessingLA,
                    Type = Infrastructure.Enums.SubjectType.User
                });

                // Applications
                var application_smCardProcessing = context.Applications.Add(new CICD.Infrastructure.Domain.Application
                {
                    Name = "SM-Card Processing (ProdBox) (Production)",
                    Infrastructure = infrastructure,
                    LineOfBusiness = warehouse,
                    Capability = cardProcessingLA,
                    Type = Infrastructure.Enums.SubjectType.Application
                });

                // Token
                var tokenUser_smCardProcessing = context.Tokens.Add(new CICD.Infrastructure.Domain.Token
                {
                    User = user_smCardProcessing,
                });
                var tokenApp_smCardProcessing = context.Tokens.Add(new CICD.Infrastructure.Domain.Token
                {
                    Application = application_smCardProcessing,
                });

                //
                // Create categories
                //
                var beverages = context.Categories.Add(new Category { CategoryName = "Beverages" });
                var condiments = context.Categories.Add(new Category { CategoryName = "Condiments" });
                var confections = context.Categories.Add(new Category { CategoryName = "Confections" });

                // Create beverages
                context.Products.Add(new Product { ProductName = "Chai", Price = 10, Category = beverages });
                context.Products.Add(new Product { ProductName = "Chang", Price = 20, Category = beverages });
                context.Products.Add(new Product { ProductName = "Ipoh Coffee", Price = 30, Category = beverages });

                // Create condiments
                context.Products.Add(new Product { ProductName = "Aniseed Syrup", Price = 40, Category = condiments });

                // Create confections
                context.Products.Add(new Product { ProductName = "Chocolade", Price = 50, Category = confections });
                context.Products.Add(new Product { ProductName = "Maxilaku", Price = 60, Category = confections });

                // Persist changes
                context.SaveChanges();
            }
        }

        private static void QueryData()
        {
            using (var context = new SampleContext())
            {
                // Get categories
                var categories = context.Categories.OrderBy(c => c.CategoryName);
                foreach (var category in categories)
                {
                    Console.WriteLine("{0} {1}", category.Id, category.CategoryName);
                }

                // Get products by category
                Console.WriteLine("\nCategory Id:");
                var categoryId = int.Parse(Console.ReadLine());
                var products = from p in context.Products
                               where p.CategoryId == categoryId
                               orderby p.ProductName
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine("{0} {1} {2}",
                        product.Id, product.ProductName, product.Price.ToString("C"));
                }
            }
        }

        private static void LazyLoading()
        {
            using (var context = new SampleContext())
            {
                // Log SQL to the console
                context.Database.Log = Console.Write;

                // Get category and related products
                Console.WriteLine("Category Id:");
                var categoryId = int.Parse(Console.ReadLine());
                var category = context.Categories.Single(c => c.Id == categoryId);
                foreach (var product1 in category.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        product1.Id, product1.ProductName, product1.Price.ToString("C"),
                        product1.Category.CategoryName);
                }

                // Get product and related category
                Console.WriteLine("Product Id:");
                var productId = int.Parse(Console.ReadLine());
                var product2 = context.Products.Single(p => p.Id == productId);
                Console.WriteLine("{0} {1} {2} {3}",
                    product2.Id, product2.ProductName, product2.Price.ToString("C"),
                    product2.Category.CategoryName);
            }
        }
    }
}