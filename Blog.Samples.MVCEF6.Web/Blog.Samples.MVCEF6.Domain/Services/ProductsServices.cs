using System.Collections.Generic;
using System.Linq;
using Blog.Samples.MVCEF6.Data.DataAcess;
using Blog.Samples.MVCEF6.Data.DatabaseModel;

namespace Blog.Samples.MVCEF6.Domain.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly IRepository<Vendor> _vendorsRepository;
        private readonly IRepository<ProductVendor> _productsVendorsRepository;

        public ProductsServices(IRepository<Product> productsRepository,
            IRepository<Vendor> vendorsRepository,
            IRepository<ProductVendor> productsVendorsRepository)
        {
            _productsRepository = productsRepository;
            _vendorsRepository = vendorsRepository;
            _productsVendorsRepository = productsVendorsRepository;
        }

        public IEnumerable<Product> ListProductsByVendor(int businessEntityID)
        {
            return _productsRepository.Find(a => a.ProductVendors.Any(pv => pv.BusinessEntityID == businessEntityID));
        }

        public IEnumerable<Vendor> ListVendors()
        {
            return _vendorsRepository.GetAll();
        }
    }
}
