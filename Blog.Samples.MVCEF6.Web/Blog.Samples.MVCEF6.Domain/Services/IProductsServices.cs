using System.Collections.Generic;
using Blog.Samples.MVCEF6.Data.DatabaseModel;


namespace Blog.Samples.MVCEF6.Domain.Services
{
    public interface IProductsServices
    {
        IEnumerable<Product> ListProductsByVendor(int businessEntityID);
        IEnumerable<Vendor> ListVendors();
    }
}
