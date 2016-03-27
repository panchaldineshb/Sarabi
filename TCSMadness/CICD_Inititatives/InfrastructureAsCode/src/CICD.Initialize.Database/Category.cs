using System.Collections.Generic;

namespace CICD.Initialize.Database
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; } // virtual for lazy loading
    }
}