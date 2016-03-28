using Blog.Samples.MVCEF6.Data.DatabaseModel;
using System.Collections.Generic;

namespace Blog.Samples.MVCEF6.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Vendor> Vendors { get; set; }

        public int SelectedBusinessEntityID { get; set; }
    }
}