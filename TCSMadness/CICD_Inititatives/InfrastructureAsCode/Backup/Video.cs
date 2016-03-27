using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoStore.Domain
{
    public class Video : IEntity
    {

        public int Id { get;  set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public int YearReleased { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal RentalPrice { get; set; }
        public int RentalDays { get; set; }
        public void Rent(int customerId) { }
       
    }
}
